using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class VerResidentes : Form
    {
        private readonly IResidenteRepository _residentRepository;
        private BindingSource bindingSource = new BindingSource();

        public VerResidentes(IResidenteRepository residenteRepository)
        {
            _residentRepository = residenteRepository;
            InitializeComponent();
        }

        private async void VerResidentes_Load(object sender, EventArgs e)
        {
            // Cargar los residentes al DataGridView    
            var residentes = await ObtenerResidentes();  // Usamos 'await' para esperar la tarea asincrónica
            bindingSource.DataSource = residentes;
            dgvResidentes.DataSource = bindingSource;

            // Configurar las columnas que se mostrarán
            dgvResidentes.Columns["Nombres"].HeaderText = "Nombres";
            dgvResidentes.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvResidentes.Columns["Tel"].HeaderText = "Teléfono";
            dgvResidentes.Columns["Correo"].HeaderText = "Correo";
            dgvResidentes.Columns["Estado"].HeaderText = "Estado";

            dgvResidentes.Columns["DocID"].Visible = false;
            dgvResidentes.Columns["PassHash"].Visible = false;
            dgvResidentes.Columns["Fecha"].Visible = false;
            dgvResidentes.Columns["Estado"].Visible = false;
            dgvResidentes.Columns["Casas"].Visible = false;
            dgvResidentes.Columns["PersonasRelacionadas"].Visible = false;
            dgvResidentes.Columns["NombreCompleto"].Visible = false;
  
        }

        // Método para obtener los residentes de forma asincrónica
        private async Task<BindingList<Residente>> ObtenerResidentes()
        {
            try
            {
                
                var residentes = await _residentRepository.ObtenerTodos();  // Línea 49

                return new BindingList<Residente>(residentes.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al obtener los residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Residente>(); // Retornar lista vacía en caso de error
            }
        }

        // Evento para eliminar un residente
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResidentes.SelectedRows.Count > 0)
            {
                var residenteSeleccionado = (Residente)dgvResidentes.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este residente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        await _residentRepository.Eliminar(residenteSeleccionado.Id);
                        MessageBox.Show("Residente eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar los residentes actualizados después de la eliminación
                        await CargarResidentesActualizados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al eliminar el residente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un residente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para editar un residente
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvResidentes.SelectedRows.Count > 0)
            {
                var residenteSeleccionado = (Residente)dgvResidentes.SelectedRows[0].DataBoundItem;
                var editarForm = new EditarResidente(residenteSeleccionado.Id, _residentRepository);

                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    // Después de la edición, recargar la lista de residentes
                    await CargarResidentesActualizados();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un residente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CargarResidentesActualizados()
        {
            // Limpiar cualquier filtro aplicado al BindingSource
            bindingSource.Clear();

            // Cargar nuevamente los residentes desde el repositorio
            var residentes = await ObtenerResidentes();
            bindingSource.DataSource = residentes;
            dgvResidentes.DataSource = bindingSource;
        }

        // Evento para buscar residentes
        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Verifica si el texto de búsqueda tiene al menos 3 caracteres
            if (!string.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                try
                {
                    // Obtener los residentes de manera asincrónica
                    var residentes = await ObtenerResidentes();

                    // Filtrar los residentes en memoria
                    var residentesFiltrados = residentes
                        .Where(r => (r.Nombres + " " + r.Apellidos).ToLower().Contains(filtro) ||
                                    r.Tel.ToLower().Contains(filtro) ||
                                    r.Correo.ToLower().Contains(filtro))
                        .ToList();

                    // Asignar los residentes filtrados al BindingSource
                    bindingSource.DataSource = new BindingList<Residente>(residentesFiltrados);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al buscar residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var residentes = await ObtenerResidentes();
                bindingSource.DataSource = new BindingList<Residente>(residentes);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            bindingSource.RemoveFilter();
        }

        private void VerResidentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource.RemoveFilter();
        }
    }
}
