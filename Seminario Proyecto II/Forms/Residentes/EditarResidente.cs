using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class EditarResidente : Form
    {
        private readonly IResidenteRepository _residenteRepository;
        private Residente _residente;

       
        public EditarResidente(int residenteId, IResidenteRepository residenteRepository)
        {
            InitializeComponent();
            _residenteRepository = residenteRepository;
            CargarDatos(residenteId);
        }

      
        private async void CargarDatos(int residenteId)
        {
            try
            {
                
                _residente = await _residenteRepository.ObtenerPorId(residenteId);

                if (_residente != null)
                {
                    
                    txtNombre.Text = _residente.Nombres?.Trim();
                    txtApellido.Text = _residente.Apellidos?.Trim();
                    txtTel.Text = _residente.Tel?.Trim();
                    txtCorreo.Text = _residente.Correo?.Trim();

                }
                else
                {
                    MessageBox.Show("No se encontró el residente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos del residente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private bool ValidarCampos()
        {
            var context = new ValidationContext(_residente, serviceProvider: null, items: null);
            var results = new System.Collections.Generic.List<ValidationResult>();

            
            bool isValid = Validator.TryValidateObject(_residente, context, results, validateAllProperties: true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    MessageBox.Show(validationResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isValid;
        }


        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }

                _residente.Nombres = txtNombre.Text;
                _residente.Apellidos = txtApellido.Text;
                _residente.Tel = txtTel.Text;
                _residente.Correo = txtCorreo.Text;

                await _residenteRepository.Actualizar(_residente);

                DialogResult result = MessageBox.Show("Residente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK; // Confirmar que los cambios fueron guardados                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
