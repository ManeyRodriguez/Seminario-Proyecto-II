using Seminario_Proyecto_II.Data.Interfaces;
using Seminario_Proyecto_II.Data.Models;
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
          
            var residentes = await ObtenerResidentes();  
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

        
        private async Task<BindingList<Residente>> ObtenerResidentes()
        {
            try
            {
                
                var residentes = await _residentRepository.ObtenerTodos();  

                return new BindingList<Residente>(residentes.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al obtener los residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Residente>(); 
            }
        }

        
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

     
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvResidentes.SelectedRows.Count > 0)
            {
                var residenteSeleccionado = (Residente)dgvResidentes.SelectedRows[0].DataBoundItem;
                var editarForm = new EditarResidente(residenteSeleccionado.Id, _residentRepository);

                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                   
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
            
            bindingSource.Clear();            
            var residentes = await ObtenerResidentes();
            bindingSource.DataSource = residentes;
            dgvResidentes.DataSource = bindingSource;
        }

        
        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                try
                {
                    
                    var residentes = await ObtenerResidentes();
                    
                    var residentesFiltrados = residentes
                        .Where(r => (r.Nombres + " " + r.Apellidos).ToLower().Contains(filtro) ||
                                    r.Tel.ToLower().Contains(filtro) ||
                                    r.Correo.ToLower().Contains(filtro))
                        .ToList();
                    
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
