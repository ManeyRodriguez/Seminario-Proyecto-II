using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class AgregarResidente : Form
    {
        private readonly IResidenteRepository _residenteRepository;

        // Inyección de dependencias a través del constructor
        public AgregarResidente(IResidenteRepository residenteRepository)
        {
            InitializeComponent();
            _residenteRepository = residenteRepository ?? throw new ArgumentNullException(nameof(residenteRepository));
        }

        private void AgregarResidente_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            txtNombres.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



    private async void BtnGuardar_Click(object sender, EventArgs e)
    {
        // Verificar que todos los campos estén completos
        if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
            string.IsNullOrEmpty(txtDocID.Text) || string.IsNullOrEmpty(txtCorreo.Text) ||
            string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtPassHash.Text) ||
            string.IsNullOrEmpty(txtPassHashConfirm.Text) || string.IsNullOrEmpty(txtDocID.Text))
        {
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        // Validar que las contraseñas coincidan
        if (txtPassHash.Text != txtPassHashConfirm.Text)
        {
            MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassHashConfirm.Focus();
            return;
        }

        // Crear un nuevo objeto Residente con los datos del formulario
        Residente nuevoResidente = new Residente
        {
            Nombres = txtNombres.Text,
            Apellidos = txtApellidos.Text,
            DocID = txtDocID.Text,
            Correo = txtCorreo.Text,
            Tel = txtTel.Text,
            PassHash = txtPassHash.Text,
            Estado = cmbEstado.SelectedItem.ToString(),
        };

        // Lista para almacenar los errores de validación
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


    // Limpiar los controles del formulario
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

        // Método para validar el formato del correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
