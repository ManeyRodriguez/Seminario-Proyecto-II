using Seminario_Proyecto_II.Data.Interfaces;
using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Casas
{
    public partial class AgregarCasa : Form
    {
        private readonly ICasaRepository _casaRepository;

      
        public AgregarCasa(ICasaRepository casaRepository)
        {
            InitializeComponent();
            _casaRepository = casaRepository ?? throw new ArgumentNullException(nameof(casaRepository));
        }

        private void AgregarCasa_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            txtCalle.Focus();
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtNumCasa.Text) ||
                cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            Casa nuevaCasa = new Casa
            {
                Calle = txtCalle.Text,
                NumCasa = txtNumCasa.Text,
                Tipo = cmbTipo.SelectedItem.ToString(),
                Fecha = DateTime.Now
            };

            
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(nuevaCasa, new ValidationContext(nuevaCasa), validationResults, true);

            if (!isValid)
            {
                var errorMessages = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
                MessageBox.Show(errorMessages, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                await _casaRepository.Agregar(nuevaCasa);
                MessageBox.Show("Casa agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error, no se pudo agregar la casa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
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
            cmbTipo.SelectedIndex = 0;
        }
    }
}
