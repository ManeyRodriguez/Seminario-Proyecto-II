using Seminario_Proyecto_II.Data.Repositories;
using Seminario_Proyecto_II.Data.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Login
{
    public partial class LoginForm : Form
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly ICasaRepository _casaRepository;
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IPersonaRelacionadaRepository _personaRelacionadaRepository;


        public LoginForm(IResidenteRepository residenteRepository, ICasaRepository casaRepository, IAdministradorRepository administradorRepository, IPersonaRelacionadaRepository personaRelacionadaRepository)
        {
            _casaRepository = casaRepository;
            _residenteRepository = residenteRepository;
            _administradorRepository = administradorRepository; 
            _personaRelacionadaRepository=personaRelacionadaRepository;
            InitializeComponent();
            ApplyCustomStyles();
            
        }
             
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var administrador = await _administradorRepository.ValidarLogin(username, password);

                if (administrador != null)
                {
                    var mainForm = new MainForm(_residenteRepository, _casaRepository, administrador, _personaRelacionadaRepository);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = textBoxPassword.PasswordChar == '\0' ? '*' : '\0';
        }

      
        private void ApplyCustomStyles()
        {
            this.BackColor = System.Drawing.Color.FromArgb(34, 34, 34);

            foreach (Control control in this.Controls)
            {
                switch (control)
                {
                    case Button button:
                        CustomizeButton(button);
                        break;

                    case Label label:
                        CustomizeLabel(label);
                        break;

                    case TextBox textBox:
                        CustomizeTextBox(textBox);
                        break;
                }
            }
        }

        private void CustomizeButton(Button button)
        {
            button.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        }

        
        private void CustomizeLabel(Label label)
        {
            label.ForeColor = System.Drawing.Color.White;
            label.Font = new System.Drawing.Font("Arial", 10F);
        }


        private void CustomizeTextBox(TextBox textBox)
        {
            textBox.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            textBox.ForeColor = System.Drawing.Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
        }
    }
}
