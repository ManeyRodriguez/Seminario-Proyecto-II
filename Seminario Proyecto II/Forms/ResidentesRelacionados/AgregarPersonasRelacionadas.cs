using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Seminario_Proyecto_II.Helpers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Seminario_Proyecto_II.Data.Interfaces;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class AgregarPersonasRelacionadas : Form
    {
        private readonly IPersonaRelacionadaRepository _personaRelacionadaRepository;
        private readonly ICasaRepository _casaRepository;
        private int? casaIdSeleccionada;

        public AgregarPersonasRelacionadas(IPersonaRelacionadaRepository personaRelacionadaRepository, ICasaRepository casaRepository)
        {
            InitializeComponent();
            _personaRelacionadaRepository = personaRelacionadaRepository ?? throw new ArgumentNullException(nameof(personaRelacionadaRepository));
            _casaRepository = casaRepository ?? throw new ArgumentNullException(nameof(casaRepository));
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
            cmbTipoPersona.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0; 
            casaIdSeleccionada = null;
        }




        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
                string.IsNullOrEmpty(txtDocID.Text) || cmbTipoPersona.SelectedItem == null ||
                casaIdSeleccionada == null || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos, seleccione un estado y una casa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Funciones.IsValidDocID(txtDocID.Text))
            {
                MessageBox.Show("El documento de identidad no es válido. Debe contener entre 11 y 20 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool estadoSeleccionado = (bool)((dynamic)cmbEstado.SelectedItem).Valor; 

            PersonaRelacionada nuevaPersonaRelacionada = new PersonaRelacionada
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                DocID = txtDocID.Text,
                Tel = txtTelefono.Text,
                Tipo = (TipoPersona)cmbTipoPersona.SelectedIndex + 1,
                CasaId = casaIdSeleccionada.Value,
                Estado = estadoSeleccionado,
                Pin = txtPin.Text,
                FechayHoraExp = ObtenerFechaHoraCombinada()
            };

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

        private void AgregarPersonasRelacionadas_Load_1(object sender, EventArgs e)
        {
            CargarComboBoxTipoPersona();
            CargarComboBoxEstado(); 
            cmbTipoPersona.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            OcultarFechayHora();
            txtNombres.Focus();
            txtPin.Text = Funciones.GenerarPin();
        }

        private void CargarComboBoxTipoPersona()
        {
            cmbTipoPersona.Items.Clear();

            foreach (TipoPersona tipo in Enum.GetValues(typeof(TipoPersona)))
            {
                cmbTipoPersona.Items.Add(tipo.ToString());
            }

            cmbTipoPersona.SelectedIndex = 0;
        }

        private void CargarComboBoxEstado()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add(new Funciones.EstadoItem { Texto = "Activo", Valor = true });
            cmbEstado.Items.Add(new Funciones.EstadoItem { Texto = "Inactivo", Valor = false });
        }

        private void OcultarFechayHora()
        {
            dtpTiempoExp.Visible = false;
            dtpFechaExp.Visible = false;
            lblFechaExp.Visible = false;
        }

        private void MostrarFechayHora()
        {
            dtpTiempoExp.Visible = true;
            dtpFechaExp.Visible = true;
            lblFechaExp.Visible = true;
        }

        private DateTime ObtenerFechaHoraCombinada()
        {
            DateTime fecha = dtpFechaExp.Value.Date;
            TimeSpan hora = dtpTiempoExp.Value.TimeOfDay;
            return fecha + hora;
        }



        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTipoPersona.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de persona válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                TipoPersona personaTipoSelecc = (TipoPersona)Enum.Parse(typeof(TipoPersona), cmbTipoPersona.SelectedItem.ToString());

               
                switch (personaTipoSelecc)
                {
                    case TipoPersona.Trabajador:
                    case TipoPersona.Invitado:
                        MostrarFechayHora(); 
                        break;

                    case TipoPersona.Familiar:
                        OcultarFechayHora();
                        break;

                    default:
                        MostrarFechayHora(); 
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El tipo de persona seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscarCasa_MouseClick(object sender, MouseEventArgs e)
        {
           
            string busqueda = txtBuscarCasa.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda para buscar casas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                
                var casas = await _casaRepository.BuscarCasas(busqueda);
                
                if (!casas.Any())
                {
                    MessageBox.Show("No se encontraron casas.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvResultadosBusqueda.DataSource = null; 
                    return;
                }
                
                dgvResultadosBusqueda.DataSource = casas.Select(c => new
                {
                    CasaId = c.Id,
                    Calle = c.Calle,
                    Tipo = c.Tipo,
                    NumCasa = c.NumCasa,
                    Asignada = c.Asignada
                }).ToList();
            }
            catch (Exception)
            {
               
                MessageBox.Show($"No se encontraron casas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvResultadosBusqueda.DataSource = null; 
            }
        }
        private void dgvResultadosBusqueda_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {                
                var filaSeleccionada = dgvResultadosBusqueda.Rows[e.RowIndex];                
                casaIdSeleccionada = (int)filaSeleccionada.Cells["CasaId"].Value;                
                string calle = filaSeleccionada.Cells["Calle"].Value.ToString();
                string tipo = filaSeleccionada.Cells["Tipo"].Value.ToString();
                string numCasa = filaSeleccionada.Cells["NumCasa"].Value.ToString();
                string asignada = filaSeleccionada.Cells["Asignada"].Value.ToString();                
                lblCasaSelecc.Text = $"[ {casaIdSeleccionada} ] Calle {calle} {tipo} # {numCasa}, Propietario: {asignada}";
            }
        }

        private void dtpFechaExp_ValueChanged(object sender, EventArgs e)
        {           
            ValidarFechaYHora();
        }

        private void dtpTiempoExp_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechaYHora();
        }
        private void ValidarFechaYHora()
        {
          
            DateTime fechaHoraSeleccionada = ObtenerFechaHoraCombinada();            
            DateTime fechaHoraActual = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            
            if (fechaHoraSeleccionada < fechaHoraActual)
            {                
                MessageBox.Show("La fecha y hora no pueden ser menores que la actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);              
                dtpFechaExp.Value = DateTime.Now.Date;
                dtpTiempoExp.Value = DateTime.Now;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {           
            ClearForm();
        }
    }
}