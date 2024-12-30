using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Casas
{
    public partial class VerCasas : Form
    {
        private readonly ICasaRepository _casaRepository;
        private readonly IResidenteRepository _residenteRepository;
        private BindingSource bindingSource = new BindingSource();

        public VerCasas(ICasaRepository casaRepository, IResidenteRepository residenteRepository)
        {
            _casaRepository = casaRepository;
            _residenteRepository = residenteRepository;
            InitializeComponent();
        }

        private async void VerCasas_Load(object sender, EventArgs e)
        {
              
            var casas = await ObtenerCasas();  
            bindingSource.DataSource = casas;
            dgvCasas.DataSource = bindingSource;

         
            dgvCasas.Columns["Calle"].HeaderText = "Calle";
            dgvCasas.Columns["NumCasa"].HeaderText = "Número";
            dgvCasas.Columns["Tipo"].HeaderText = "Tipo";
            dgvCasas.Columns["Fecha"].HeaderText = "Fecha";

            dgvCasas.Columns["Id"].Visible = false;
            dgvCasas.Columns["ResidenteId"].Visible = false;
            dgvCasas.Columns["Residente"].Visible = false;
            dgvCasas.Columns["Fecha"].Visible = false;
        }

     
        private async Task<BindingList<Casa>> ObtenerCasas()
        {
            try
            {
                var casas = await _casaRepository.ObtenerTodos();
                return new BindingList<Casa>(casas.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al obtener las casas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Casa>(); 
            }
        }

    
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCasas.SelectedRows.Count > 0)
            {
                var casaSeleccionada = (Casa)dgvCasas.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta casa?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        await _casaRepository.Eliminar(casaSeleccionada.Id);
                        MessageBox.Show("Casa eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        await CargarCasasActualizadas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al eliminar la casa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una casa para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCasas.SelectedRows.Count > 0)
            {
               var casaSeleccionada = (Casa)dgvCasas.SelectedRows[0].DataBoundItem;
               var editarForm = new EditarCasa(casaSeleccionada.Id, _casaRepository, _residenteRepository);

               if (editarForm.ShowDialog() == DialogResult.OK)
               {
                    
                    await CargarCasasActualizadas();
               }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una casa para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CargarCasasActualizadas()
        {
            
            bindingSource.Clear();

            
            var casas = await ObtenerCasas();
            bindingSource.DataSource = casas;
            dgvCasas.DataSource = bindingSource;
        }

      
        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                try
                {
                    
                    var casas = await ObtenerCasas();
                   
                    var casasFiltradas = casas
                        .Where(c => c.Calle.ToLower().Contains(filtro) ||
                                    c.NumCasa.ToLower().Contains(filtro) ||
                                    c.Tipo.ToLower().Contains(filtro))
                        .ToList();

                   
                    bindingSource.DataSource = new BindingList<Casa>(casasFiltradas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al buscar casas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var casas = await ObtenerCasas();
                bindingSource.DataSource = new BindingList<Casa>(casas);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            bindingSource.RemoveFilter();
        }

        private void VerCasas_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource.RemoveFilter();
        }
    }
}
