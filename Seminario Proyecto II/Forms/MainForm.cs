using Seminario_Proyecto_II.Data.Repositories;
using Seminario_Proyecto_II.Forms.Casas;
using Seminario_Proyecto_II.Forms.Residentes;
using Seminario_Proyecto_II.Data.Models; // Para acceder a la clase Administrador
using System;
using System.Globalization;
using System.Windows.Forms;
using Seminario_Proyecto_II.Forms.ResidentesRelacionados;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Seminario_Proyecto_II.Forms
{
    public partial class MainForm : Form
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly ICasaRepository _casaRepository;
        private readonly IPersonaRelacionadaRepository _personaRelacionadaRepository;
        private readonly Administrador _administrador;

        public MainForm(IResidenteRepository residenteRepository, ICasaRepository casaRepository, Administrador administrador, IPersonaRelacionadaRepository personaRelacionadaRepository)
        {
            _residenteRepository = residenteRepository;
            _casaRepository = casaRepository;
            _administrador = administrador;
            _personaRelacionadaRepository=personaRelacionadaRepository;
            InitializeComponent();
            ApplyAdminNameToTitle();
        }



        private async void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ApplyAdminNameToTitle()
        {
            labelTitle.Text = $"Bienvenido, {_administrador.NombreCompleto}";
        }


        private void verResidentesMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerResidentes(_residenteRepository));
        }


        private void agregarResidenteMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AgregarResidente(_residenteRepository));
        }



        private void agregarPersonaRelacionadaMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AgregarPersonasRelacionadas(_personaRelacionadaRepository, _casaRepository));
        }

        private void verPersonasRelacionadasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerPersonasRelacionadas(_personaRelacionadaRepository));
        }


        private void agregarCasaMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new AgregarCasa(_casaRepository));
        }

        private void verCasasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerCasas(_casaRepository, _residenteRepository));
        }


        private void AbrirFormulario(Form form)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == form.GetType())
                {
                    f.BringToFront();
                    return;
                }
            }
            form.Show();
        }


        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            DateTime now = DateTime.Now;
            string formattedDateTime = $"{now.ToString("dddd dd 'de' MMMM 'del año' yyyy", culture)} | {now.ToString("hh:mm:ss tt", culture)}";
            toolStripStatusLabelDateTime.Text = formattedDateTime;
        }

        private async void MainForm_Activated(object sender, EventArgs e)
        {

        }


        private async void btnBusqueda_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                var residentes = await _residenteRepository.ObtenerTodos() ?? new List<Residente>();
                var resultadoResidentes = residentes.Where(r =>
                    (!string.IsNullOrEmpty(r.NombreCompleto) && r.NombreCompleto.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.Pin) && r.Pin.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.DocID) && r.DocID.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(r => new PersonaBusqueda
                    {
                        Nombre = r.NombreCompleto,
                        DocID = r.DocID,
                        Casa = r.Casas.FirstOrDefault()?.Tipo ?? "No asignada",
                        Calle = r.Casas.FirstOrDefault()?.Calle ?? "No registrada",
                        Numero = r.Casas.FirstOrDefault()?.NumCasa ?? "No registrada",
                        TipoPersona = "Residente"
                    })
                    .ToList();


                var personasRelacionadas = await _personaRelacionadaRepository.ObtenerTodos() ?? new List<PersonaRelacionada>();
                var resultadoPersonasRelacionadas = personasRelacionadas.Where(p =>
                    (!string.IsNullOrEmpty(p.NombreCompleto) && p.NombreCompleto.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(p.Pin) && p.Pin.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(p.DocID) && p.DocID.IndexOf(criterioBusqueda, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(p => new PersonaBusqueda
                    {
                        Nombre = p.NombreCompleto,
                        DocID = p.DocID,
                        Casa = p.Casa?.Tipo ?? "No asignada",
                        Calle = p.Casa?.Calle ?? "No registrada",
                        Numero = p.Casa?.NumCasa ?? "No registrada",
                        TipoPersona = p.Tipo.ToString(),
                        FechaHoraExp = p.FechayHoraExp
                    })
                    .ToList();


                var resultados = resultadoResidentes.Union(resultadoPersonasRelacionadas).ToList();


                dgvBusqueda.DataSource = resultados;
            }
            catch (Exception ex)
            {
                lblAcceso.Text = "Seleccionada: ";
                MessageBox.Show($"Ocurrió un error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvBusqueda_SelectionChanged(object sender, EventArgs e)
        {

    
        }


        private void btnAcceso_Click(object sender, EventArgs e)
        {

          

            if (dgvBusqueda.SelectedRows.Count > 0)
            {

                DataGridViewRow row = dgvBusqueda.SelectedRows[0];
                string tipoPersona = row.Cells["TipoPersona"].Value.ToString();
                DateTime? fechaHoraExp = row.Cells["FechaHoraExp"].Value as DateTime?;
                VerificarAcceso(tipoPersona, fechaHoraExp);
            }
            else
            {
                lblAcceso.Text = "Seleccionada: ";
                MessageBox.Show("Por favor debe seleccionar una  persona.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VerificarAcceso(string tipoPersona, DateTime? fechaHoraExp)
        {
            DateTime fechaHoraActual = DateTime.Now;


            if (tipoPersona == "Residente")
            {

                MessageBox.Show("Acceso permitido.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipoPersona == "Familiar")
            {

                MessageBox.Show("Acceso permitido.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipoPersona == "Invitado" || tipoPersona == "Trabajador")
            {

                if (fechaHoraExp.HasValue && fechaHoraExp.Value >= fechaHoraActual)
                {
                    MessageBox.Show("Acceso permitido.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Acceso denegado. La fecha y hora de expiración ha pasado.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                MessageBox.Show("Tipo de persona desconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
               
                DataGridViewRow row = dgvBusqueda.Rows[e.RowIndex];

                
                string nombre = row.Cells["Nombre"].Value?.ToString();

                
                if (!string.IsNullOrEmpty(nombre))
                {
                    lblAcceso.Text = "Seleccionada: " + nombre;
                }
                else
                {
                    lblAcceso.Text = "Seleccionada: (Nombre no disponible)";
                }
            }
            else
            {
                lblAcceso.Text = "Seleccionada: ";
            }
        }



        


    }
}
