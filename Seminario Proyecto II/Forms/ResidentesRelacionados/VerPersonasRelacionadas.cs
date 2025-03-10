﻿using Seminario_Proyecto_II.Data.Interfaces;
using Seminario_Proyecto_II.Data.Models;
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
            
            var personasRelacionadas = await ObtenerPersonasRelacionadas();
            bindingSource.DataSource = personasRelacionadas;
            dgvPersonasRelacionadas.DataSource = bindingSource;

            dgvPersonasRelacionadas.Columns["Nombres"].HeaderText = "Nombres";
            dgvPersonasRelacionadas.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvPersonasRelacionadas.Columns["DocID"].HeaderText = "Documento ID";
            dgvPersonasRelacionadas.Columns["Tel"].HeaderText = "Teléfono";
            dgvPersonasRelacionadas.Columns["Tipo"].HeaderText = "Tipo de Persona";

           
            dgvPersonasRelacionadas.Columns["Casa"].Visible = false;
           
        }

        
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

     
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private async Task CargarPersonasRelacionadasActualizadas()
        {
           
            bindingSource.Clear();

          
            var personasRelacionadas = await ObtenerPersonasRelacionadas();
            bindingSource.DataSource = personasRelacionadas;
            dgvPersonasRelacionadas.DataSource = bindingSource;
        }

        
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
