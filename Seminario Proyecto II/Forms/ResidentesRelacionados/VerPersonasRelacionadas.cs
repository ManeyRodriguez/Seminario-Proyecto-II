using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.ResidentesRelacionados
{
    public partial class VerPersonasRelacionadas : Form
    {
        private readonly IPersonaRelacionadaRepository _personaRelacionadaRepository;
        private BindingSource bindingSource = new BindingSource();

        public VerPersonasRelacionadas(IPersonaRelacionadaRepository personaRelacionadaRepository)
        {
            _personaRelacionadaRepository = personaRelacionadaRepository;
            InitializeComponent();
        }

        private async void VerPersonasRelacionadas_Load(object sender, EventArgs e)
        {
            // Cargar las personas relacionadas al DataGridView
            var personasRelacionadas = await ObtenerPersonasRelacionadas();
            bindingSource.DataSource = personasRelacionadas;
            dgvPersonasRelacionadas.DataSource = bindingSource;

            // Configurar las columnas que se mostrarán
            dgvPersonasRelacionadas.Columns["Nombres"].HeaderText = "Nombres";
            dgvPersonasRelacionadas.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvPersonasRelacionadas.Columns["DocID"].HeaderText = "Documento ID";
            dgvPersonasRelacionadas.Columns["Tel"].HeaderText = "Teléfono";
            dgvPersonasRelacionadas.Columns["Tipo"].HeaderText = "Tipo de Persona";

            // Ocultar columnas innecesarias
            dgvPersonasRelacionadas.Columns["Casa"].Visible = false;
            dgvPersonasRelacionadas.Columns["CodigosDeAcceso"].Visible = false;
        }

        // Método para obtener las personas relacionadas de forma asincrónica
        private async Task<BindingList<PersonaRelacionada>> ObtenerPersonasRelacionadas()
        {
            try
            {
                var personasRelacionadas = await _personaRelacionadaRepository.ObtenerTodos();
                return new BindingList<PersonaRelacionada>(personasRelacionadas.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al obtener las personas relacionadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<PersonaRelacionada>();
            }
        }

        // Evento para eliminar una persona relacionada
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonasRelacionadas.SelectedRows.Count > 0)
            {
                var personaSeleccionada = (PersonaRelacionada)dgvPersonasRelacionadas.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta persona?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        await _personaRelacionadaRepository.Eliminar(personaSeleccionada.Id);
                        MessageBox.Show("Persona eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar la lista actualizada después de la eliminación
                        await CargarPersonasRelacionadasActualizadas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al eliminar la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una persona para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para editar una persona relacionada
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPersonasRelacionadas.SelectedRows.Count > 0)
            {
                var personaSeleccionada = (PersonaRelacionada)dgvPersonasRelacionadas.SelectedRows[0].DataBoundItem;
               /* var editarForm = new EditarPersonaRelacionada(personaSeleccionada.Id, _personaRelacionadaRepository);

                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    // Recargar lista después de la edición
                    await CargarPersonasRelacionadasActualizadas();
                }
               */
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una persona para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CargarPersonasRelacionadasActualizadas()
        {
            // Limpiar cualquier filtro aplicado al BindingSource
            bindingSource.Clear();

            // Cargar nuevamente las personas relacionadas desde el repositorio
            var personasRelacionadas = await ObtenerPersonasRelacionadas();
            bindingSource.DataSource = personasRelacionadas;
            dgvPersonasRelacionadas.DataSource = bindingSource;
        }

        // Evento para buscar personas relacionadas
        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                try
                {
                    var personasRelacionadas = await ObtenerPersonasRelacionadas();

                    var personasFiltradas = personasRelacionadas
                        .Where(p => (p.Nombres + " " + p.Apellidos).ToLower().Contains(filtro) ||
                                    p.DocID.ToLower().Contains(filtro) ||
                                    p.Tel.ToLower().Contains(filtro))
                        .ToList();

                    bindingSource.DataSource = new BindingList<PersonaRelacionada>(personasFiltradas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al buscar personas relacionadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var personasRelacionadas = await ObtenerPersonasRelacionadas();
                bindingSource.DataSource = new BindingList<PersonaRelacionada>(personasRelacionadas);
            }
        }

        private async void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                try
                {                  
                    var personasRelacionadas = await ObtenerPersonasRelacionadas();
                
                    var personasFiltradas = personasRelacionadas
                        .Where(p => (p.Nombres + " " + p.Apellidos).ToLower().Contains(filtro) ||
                                    p.DocID.ToLower().Contains(filtro) ||
                                    p.Tel.ToLower().Contains(filtro))
                        .ToList();

                  
                    bindingSource.DataSource = new BindingList<PersonaRelacionada>(personasFiltradas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al buscar personas relacionadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {                
                var personasRelacionadas = await ObtenerPersonasRelacionadas();
                bindingSource.DataSource = new BindingList<PersonaRelacionada>(personasRelacionadas);
            }
        }


        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            bindingSource.RemoveFilter();
        }

        private void VerPersonasRelacionadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource.RemoveFilter();
        }
    }
}
