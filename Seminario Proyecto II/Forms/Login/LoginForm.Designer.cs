using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Login
{
    public partial class LoginForm : Form
    {
        // Evento que maneja el clic en el botón de login
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados por el usuario
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Lógica simple de autenticación (para pruebas)
            if (username == "admin" && password == "1234") // Reemplaza por tu lógica de validación
            {
               // MessageBox.Show("Login exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes redirigir a otra pantalla si el login es exitoso
                new MainForm().Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para mostrar/ocultar la contraseña
        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            // Cambiar la visibilidad de la contraseña
            textBoxPassword.PasswordChar = (textBoxPassword.PasswordChar == '\0') ? '*' : '\0';
        }

        // Método para aplicar los estilos personalizados (colores y fuentes)
        private void ApplyCustomStyles()
        {
            // Cambiar el color de fondo del formulario
            this.BackColor = Color.FromArgb(34, 34, 34);

            // Aplicar colores a los controles (Botones, etiquetas, etc.)
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = Color.FromArgb(0, 122, 204);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Font = new Font("Arial", 9F, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    Label label = (Label)control;
                    label.ForeColor = Color.White;
                    label.Font = new Font("Arial", 10F);
                }
                else if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.BackColor = Color.FromArgb(50, 50, 50);
                    textBox.ForeColor = Color.White;
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                }
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelLogin = new Panel();
            lblVersion = new Label();
            pictureBox1 = new PictureBox();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonTogglePassword = new Button();
            buttonLogin = new Button();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(lblVersion);
            panelLogin.Controls.Add(pictureBox1);
            panelLogin.Controls.Add(labelUsername);
            panelLogin.Controls.Add(textBoxUsername);
            panelLogin.Controls.Add(labelPassword);
            panelLogin.Controls.Add(textBoxPassword);
            panelLogin.Controls.Add(buttonTogglePassword);
            panelLogin.Controls.Add(buttonLogin);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Padding = new Padding(20);
            panelLogin.Size = new Size(400, 250);
            panelLogin.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = Color.White;
            lblVersion.Location = new Point(12, 218);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(42, 23);
            lblVersion.TabIndex = 7;
            lblVersion.Text = "V 1.0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(158, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // labelUsername
            // 
            labelUsername.Font = new Font("Arial", 10F);
            labelUsername.ForeColor = Color.White;
            labelUsername.Location = new Point(97, 84);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(100, 23);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BackColor = Color.FromArgb(50, 50, 50);
            textBoxUsername.BorderStyle = BorderStyle.None;
            textBoxUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxUsername.ForeColor = Color.White;
            textBoxUsername.Location = new Point(97, 110);
            textBoxUsername.MaxLength = 50;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(200, 18);
            textBoxUsername.TabIndex = 1;
            textBoxUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // labelPassword
            // 
            labelPassword.Font = new Font("Arial", 10F);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(97, 139);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 23);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(50, 50, 50);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.Location = new Point(97, 165);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 18);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonTogglePassword
            // 
            buttonTogglePassword.BackColor = Color.Transparent;
            buttonTogglePassword.FlatStyle = FlatStyle.Flat;
            buttonTogglePassword.Font = new Font("Arial", 9F);
            buttonTogglePassword.ForeColor = Color.White;
            buttonTogglePassword.Location = new Point(303, 163);
            buttonTogglePassword.Name = "buttonTogglePassword";
            buttonTogglePassword.Size = new Size(30, 23);
            buttonTogglePassword.TabIndex = 4;
            buttonTogglePassword.Text = "👁";
            buttonTogglePassword.UseVisualStyleBackColor = false;
            buttonTogglePassword.Click += buttonTogglePassword_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(0, 122, 204);
            buttonLogin.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(158, 198);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(100, 30);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Iniciar sesión";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(400, 250);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button buttonTogglePassword;

        // Aquí debe estar la declaración de components
        //private System.ComponentModel.IContainer components;
        private PictureBox pictureBox1;
        private Label lblVersion;
    }
}
