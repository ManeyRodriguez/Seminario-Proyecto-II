namespace Seminario_Proyecto_II.Forms.Residentes
{
    partial class EditarResidente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblApellido = new Label();
            lblTel = new Label();
            lblCorreo = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTel = new TextBox();
            txtCorreo = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = SystemColors.ControlLightLight;
            lblNombre.Location = new Point(51, 51);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellido.ForeColor = SystemColors.ControlLightLight;
            lblApellido.Location = new Point(270, 51);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(60, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellidos:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTel.ForeColor = SystemColors.ControlLightLight;
            lblTel.Location = new Point(51, 124);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(59, 15);
            lblTel.TabIndex = 4;
            lblTel.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCorreo.ForeColor = SystemColors.ControlLightLight;
            lblCorreo.Location = new Point(270, 124);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(48, 15);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Correo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(51, 69);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(270, 69);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(51, 142);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(200, 23);
            txtTel.TabIndex = 5;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(270, 142);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 23);
            txtCorreo.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(205, 213);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Actualizar";
            btnGuardar.UseVisualStyleBackColor = true;
            EventHandler btnGuardar_Click = BtnGuardar_Click;
            
            // 
            // EditarResidente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(533, 290);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblTel);
            Controls.Add(txtTel);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarResidente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Residente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Declaración de controles
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnGuardar;
    }
}
