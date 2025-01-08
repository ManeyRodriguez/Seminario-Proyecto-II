using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class AgregarPersonasRelacionadas : Form
    {
        private readonly IPersonaRelacionadaRepository _personaRelacionadaRepository;
        private readonly ICasaRepository _casaRepository;
        private int? casaIdSeleccionada; // Almacena el CasaId seleccionado.

        public AgregarPersonasRelacionadas(IPersonaRelacionadaRepository personaRelacionadaRepository, ICasaRepository casaRepository)
        {
            InitializeComponent();
            _personaRelacionadaRepository = personaRelacionadaRepository ?? throw new ArgumentNullException(nameof(personaRelacionadaRepository));
            _casaRepository = casaRepository ?? throw new ArgumentNullException(nameof(casaRepository));
        }

        private void AgregarPersonasRelacionadas_Load(object sender, EventArgs e)
        {
            cmbTipoPersona.SelectedIndex = 1;
            txtNombres.Focus();



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
            cmbTipoPersona.SelectedIndex = 1;
            label1.Text = "";
            casaIdSeleccionada = null; // Limpiar la selección de CasaId.
        }

        // Método para validar el formato del documento de identidad
        private bool IsValidDocID(string docID)
        {
            try
            {
                var docIDRegex = new Regex(@"^[0-9]{11,20}$"); // Valida que el ID contenga entre 11 y 20 dígitos
                return docIDRegex.IsMatch(docID);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén completos
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
                string.IsNullOrEmpty(txtDocID.Text) || cmbTipoPersona.SelectedItem == null || casaIdSeleccionada == null)
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione una casa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el formato del documento de identidad
            if (!IsValidDocID(txtDocID.Text))
            {
                MessageBox.Show("El documento de identidad no es válido. Debe contener entre 11 y 20 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo objeto PersonaRelacionada con los datos del formulario
            PersonaRelacionada nuevaPersonaRelacionada = new PersonaRelacionada
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                DocID = txtDocID.Text,
                Tel = txtTelefono.Text,
                Tipo = (TipoPersona)cmbTipoPersona.SelectedIndex + 1, // Mapeo del índice a TipoPersona
                CasaId = casaIdSeleccionada.Value, // Asignar CasaId seleccionado
                Fecha = DateTime.Now
            };

            // Lista para almacenar los errores de validación
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(nuevaPersonaRelacionada, new ValidationContext(nuevaPersonaRelacionada), validationResults, true);

            if (!isValid)
            {
                var errorMessages = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
                MessageBox.Show(errorMessages, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await _personaRelacionadaRepository.Agregar(nuevaPersonaRelacionada);
                MessageBox.Show("Persona relacionada agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception)
            {
                MessageBox.Show($"Ocurrió un error, no se pudo agregar la persona relacionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvResultadosBusqueda_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dgvResultadosBusqueda.Rows[e.RowIndex];

                // Obtener los datos necesarios
                casaIdSeleccionada = (int)filaSeleccionada.Cells["CasaId"].Value;
                string calle = filaSeleccionada.Cells["Calle"].Value.ToString();
                string tipo = filaSeleccionada.Cells["Tipo"].Value.ToString();
                string numCasa = filaSeleccionada.Cells["NumCasa"].Value.ToString();
                string asignada = filaSeleccionada.Cells["Asignada"].Value.ToString();

                // Mostrar la información en el label
                label1.Text = $"[ {casaIdSeleccionada} ] Calle {calle} {tipo} # {numCasa}, Propietario: {asignada}";
            }
        }

        private async void btnBuscarCasa_MouseClick(object sender, MouseEventArgs e)
        {
            string busqueda = txtBuscarCasa.Text.Trim();

            // Validar entrada del usuario
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda para buscar casas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                // Realizar la búsqueda
                var casas = await _casaRepository.BuscarCasas(busqueda);

                // Asignar resultados al DataGridView
                dgvResultadosBusqueda.DataSource = casas.Any()
                    ? casas.Select(c => new
                    {
                        CasaId = c.Id,
                        Calle = c.Calle,
                        Tipo = c.Tipo,
                        NumCasa = c.NumCasa,
                        Asignada = c.Asignada
                    }).ToList()
                    : null;

                // Mostrar mensaje si no hay resultados
                if (!casas.Any())
                {
                    MessageBox.Show("No se encontraron casas.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (KeyNotFoundException knfEx)
            {
                // Manejar caso específico donde no se encontraron casas
                MessageBox.Show(knfEx.Message, "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejo genérico de errores
                MessageBox.Show($"Hubo un error al buscar las casas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
