using Seminario_Proyecto_II.Forms.Residentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void verResidentesMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormulario(new VerResidentes());
        }


        private void agregarResidenteMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new AgregarResidente());
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
            string formattedDateTime = $"{now.ToString("dddd dd 'de' MMMM 'del año' yyyy", culture)} y son las: {now.ToString("HH:mm:ss", culture)}";
            toolStripStatusLabelDateTime.Text = formattedDateTime;
        }




    }
}
