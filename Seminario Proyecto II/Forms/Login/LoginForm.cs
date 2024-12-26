using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Login
{
    public partial class LoginForm : Form
    {
        private readonly IResidenteRepository _residenteRepository;
        public LoginForm(IResidenteRepository residenteRepository)
        {
            _residenteRepository = residenteRepository;
            InitializeComponent();           
            ApplyCustomStyles();
        }

        /// <summary>
        /// Evento que maneja el clic en el botón de login.
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
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
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "1234")
                {                    
                    var mainForm = new MainForm(_residenteRepository);
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

        /// <summary>
        /// Evento para mostrar u ocultar la contraseña.
        /// </summary>
        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = textBoxPassword.PasswordChar == '\0' ? '*' : '\0';
        }

        /// <summary>
        /// Aplica estilos personalizados al formulario y sus controles.
        /// </summary>
        private void ApplyCustomStyles()
        {
          
            this.BackColor = Color.FromArgb(34, 34, 34);
         
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

        /// <summary>
        /// Personaliza un botón.
        /// </summary>
        private void CustomizeButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 122, 204);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Arial", 9F, FontStyle.Bold);
        }

        /// <summary>
        /// Personaliza una etiqueta.
        /// </summary>
        private void CustomizeLabel(Label label)
        {
            label.ForeColor = Color.White;
            label.Font = new Font("Arial", 10F);
        }

        /// <summary>
        /// Personaliza una caja de texto.
        /// </summary>
        private void CustomizeTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(50, 50, 50);
            textBox.ForeColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
        }
    }
}
