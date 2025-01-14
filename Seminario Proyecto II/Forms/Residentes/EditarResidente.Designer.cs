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
            lblPin = new Label();
            txtPin = new TextBox();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = SystemColors.ControlLightLight;
            lblNombre.Location = new Point(73, 85);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellido.ForeColor = SystemColors.ControlLightLight;
            lblApellido.Location = new Point(386, 85);
            lblApellido.Margin = new Padding(4, 0, 4, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(96, 25);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellidos:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTel.ForeColor = SystemColors.ControlLightLight;
            lblTel.Location = new Point(73, 207);
            lblTel.Margin = new Padding(4, 0, 4, 0);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(91, 25);
            lblTel.TabIndex = 4;
            lblTel.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCorreo.ForeColor = SystemColors.ControlLightLight;
            lblCorreo.Location = new Point(386, 207);
            lblCorreo.Margin = new Padding(4, 0, 4, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(74, 25);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Correo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(73, 115);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(284, 31);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(386, 115);
            txtApellido.Margin = new Padding(4, 5, 4, 5);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(284, 31);
            txtApellido.TabIndex = 3;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(73, 237);
            txtTel.Margin = new Padding(4, 5, 4, 5);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(284, 31);
            txtTel.TabIndex = 5;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(386, 237);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(284, 31);
            txtCorreo.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(288, 440);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 50);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Actualizar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPin.ForeColor = SystemColors.ControlLightLight;
            lblPin.Location = new Point(73, 313);
            lblPin.Margin = new Padding(4, 0, 4, 0);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(44, 25);
            lblPin.TabIndex = 9;
            lblPin.Text = "Pin:";
            // 
            // txtPin
            // 
            txtPin.Location = new Point(73, 343);
            txtPin.Margin = new Padding(4, 5, 4, 5);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(284, 31);
            txtPin.TabIndex = 10;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(386, 343);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(284, 33);
            cmbEstado.TabIndex = 11;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = SystemColors.ControlLightLight;
            lblEstado.Location = new Point(386, 313);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(69, 25);
            lblEstado.TabIndex = 12;
            lblEstado.Text = "Estado";
            // 
            // EditarResidente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(745, 557);
            Controls.Add(lblEstado);
            Controls.Add(cmbEstado);
            Controls.Add(lblPin);
            Controls.Add(txtPin);
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
            Margin = new Padding(4, 5, 4, 5);
            Name = "EditarResidente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Residente";
            Load += EditarResidente_Load;
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
        private Label lblPin;
        private TextBox txtPin;
        private ComboBox cmbEstado;
        private Label lblEstado;
    }
}
