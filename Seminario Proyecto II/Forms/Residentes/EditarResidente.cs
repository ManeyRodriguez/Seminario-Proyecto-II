using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using static Seminario_Proyecto_II.Helpers.Funciones;

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
                
                if (cmbEstado.Items.Count == 0)
                {
                    cmbEstado.Items.Add(new EstadoItem { Texto = "Activo", Valor = true });
                    cmbEstado.Items.Add(new EstadoItem { Texto = "Inactivo", Valor = false });
                }

               
                _residente = await _residenteRepository.ObtenerPorId(residenteId);

                if (_residente != null)
                {                    
                    txtNombre.Text = _residente.Nombres?.Trim();
                    txtApellido.Text = _residente.Apellidos?.Trim();
                    txtTel.Text = _residente.Tel?.Trim();
                    txtCorreo.Text = _residente.Correo?.Trim();
                    txtPin.Text = _residente.Pin?.Trim();

                   
                    var estadoSeleccionado = cmbEstado.Items
                        .Cast<EstadoItem>()
                        .FirstOrDefault(item => item.Valor == _residente.Estado);

                    cmbEstado.SelectedItem = estadoSeleccionado;
                }
                else
                {
                    MessageBox.Show("No se encontró el residente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del residente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
               
                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidarCampos())
                {
                    return;
                }
                
                bool estado = (cmbEstado.SelectedItem as EstadoItem)?.Valor ?? false;
                
                _residente.Nombres = txtNombre.Text.Trim();
                _residente.Apellidos = txtApellido.Text.Trim();
                _residente.Tel = txtTel.Text.Trim();
                _residente.Correo = txtCorreo.Text.Trim();
                _residente.Pin = txtPin.Text.Trim();
                _residente.Estado = estado;

              
                await _residenteRepository.Actualizar(_residente);                
                DialogResult result = MessageBox.Show("Residente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;                   
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarResidente_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

 
    }


}
