using Seminario_Proyecto_II.Data.Repositories;
using Seminario_Proyecto_II.Forms.Casas;
using Seminario_Proyecto_II.Forms.Residentes;
using System;
using System.Globalization;
using System.Windows.Forms; 

namespace Seminario_Proyecto_II.Forms
{
    public partial class MainForm : Form
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly ICasaRepository _casaRepository;

        public MainForm(IResidenteRepository residenteRepository, ICasaRepository casaRepository)
        {
            _residenteRepository = residenteRepository;
            InitializeComponent();
            _casaRepository=casaRepository;
        }

        /// <summary>
        /// Evento para ver la lista de residentes.
        /// </summary>
        private void verResidentesMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerResidentes(_residenteRepository));
        }

        /// <summary>
        /// Evento para agregar un nuevo residente.
        /// </summary>
        private void agregarResidenteMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormulario(new AgregarResidente(_residenteRepository));


        }


        /// <summary>
        /// Evento para agregar una nueva casa.
        /// </summary>
        private void agregarCasaMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new AgregarCasa(_casaRepository));
        }

        /// <summary>
        /// Evento para ver las casas.
        /// </summary>
        private void verCasasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerCasas(_casaRepository, _residenteRepository));
        }

        /// <summary>
        /// Método para abrir un formulario dentro de la aplicación.
        /// </summary>
        /// <param name="form">El formulario que se abrirá.</param>
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

        /// <summary>
        /// Evento para salir de la aplicación.
        /// </summary>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento para actualizar la fecha y hora en el status bar.
        /// </summary>
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            DateTime now = DateTime.Now;
            string formattedDateTime = $"{now.ToString("dddd dd 'de' MMMM 'del año' yyyy", culture)} y son las: {now.ToString("HH:mm:ss", culture)}";
            toolStripStatusLabelDateTime.Text = formattedDateTime;
        }

  
    }
}
