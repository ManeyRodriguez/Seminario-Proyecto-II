using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Seminario_Proyecto_II.Helpers;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class AgregarResidente : Form
    {
        private readonly IResidenteRepository _residenteRepository;

        
        public AgregarResidente(IResidenteRepository residenteRepository)
        {
            InitializeComponent();
            _residenteRepository = residenteRepository ?? throw new ArgumentNullException(nameof(residenteRepository));
        }

        private void AgregarResidente_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add(new { Text = "Activo", Value = true });
            cmbEstado.Items.Add(new { Text = "Inactivo", Value = false });
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;
            txtPin.Text = Funciones.GenerarPin();
            txtNombres.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
                string.IsNullOrEmpty(txtDocID.Text) || string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtPassHash.Text) ||
                string.IsNullOrEmpty(txtPassHashConfirm.Text) || string.IsNullOrEmpty(txtPin.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (txtPassHash.Text != txtPassHashConfirm.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassHashConfirm.Focus();
                return;
            }

            
            bool estado = (bool)((dynamic)cmbEstado.SelectedItem).Value;

         
            Residente nuevoResidente = new Residente
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                DocID = txtDocID.Text,
                Correo = txtCorreo.Text,
                Tel = txtTel.Text,
                Pin = txtPin.Text,
                PassHash = txtPassHash.Text,
                Estado = estado
            };

         
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(nuevoResidente, new ValidationContext(nuevoResidente), validationResults, true);

            if (!isValid)
            {
                var errorMessages = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
                MessageBox.Show(errorMessages, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await _residenteRepository.Agregar(nuevoResidente);
                MessageBox.Show("Residente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception)
            {
                MessageBox.Show($"Ocurrió un error, no se pudo agregar el residente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearForm()
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
            cmbEstado.SelectedIndex = 0;
        }

        
    }
}
