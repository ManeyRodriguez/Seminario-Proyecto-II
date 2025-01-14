using Seminario_Proyecto_II.Data.Models;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    partial class AgregarResidente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtDocID = new TextBox();
            txtCorreo = new TextBox();
            txtTel = new TextBox();
            txtPassHash = new TextBox();
            btnGuardar = new Button();
            lblNombres = new Label();
            lblApellidos = new Label();
            lblDocID = new Label();
            lblCorreo = new Label();
            lblTel = new Label();
            lblPassHash = new Label();
            btnLimpiar = new Button();
            label1 = new Label();
            txtPassHashConfirm = new TextBox();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            lblPin = new Label();
            txtPin = new TextBox();
            SuspendLayout();
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(84, 80);
            txtNombres.Margin = new Padding(4, 5, 4, 5);
            txtNombres.MaxLength = 50;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(284, 31);
            txtNombres.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(397, 80);
            txtApellidos.Margin = new Padding(4, 5, 4, 5);
            txtApellidos.MaxLength = 50;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(284, 31);
            txtApellidos.TabIndex = 1;
            // 
            // txtDocID
            // 
            txtDocID.Location = new Point(84, 450);
            txtDocID.Margin = new Padding(4, 5, 4, 5);
            txtDocID.Name = "txtDocID";
            txtDocID.Size = new Size(284, 31);
            txtDocID.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(84, 330);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(284, 31);
            txtCorreo.TabIndex = 4;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(397, 330);
            txtTel.Margin = new Padding(4, 5, 4, 5);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(284, 31);
            txtTel.TabIndex = 5;
            // 
            // txtPassHash
            // 
            txtPassHash.Location = new Point(84, 205);
            txtPassHash.Margin = new Padding(4, 5, 4, 5);
            txtPassHash.MaxLength = 50;
            txtPassHash.Name = "txtPassHash";
            txtPassHash.Size = new Size(284, 31);
            txtPassHash.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(538, 641);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 47);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // lblNombres
            // 
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.ForeColor = SystemColors.ControlLightLight;
            lblNombres.Location = new Point(84, 37);
            lblNombres.Margin = new Padding(4, 0, 4, 0);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(83, 38);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";
            // 
            // lblApellidos
            // 
            lblApellidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellidos.ForeColor = SystemColors.ControlLightLight;
            lblApellidos.Location = new Point(397, 37);
            lblApellidos.Margin = new Padding(4, 0, 4, 0);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(93, 38);
            lblApellidos.TabIndex = 1;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblDocID
            // 
            lblDocID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDocID.ForeColor = SystemColors.ControlLightLight;
            lblDocID.Location = new Point(84, 415);
            lblDocID.Margin = new Padding(4, 0, 4, 0);
            lblDocID.Name = "lblDocID";
            lblDocID.Size = new Size(233, 30);
            lblDocID.TabIndex = 2;
            lblDocID.Text = "Documento de Identidad:";
            // 
            // lblCorreo
            // 
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCorreo.ForeColor = SystemColors.ControlLightLight;
            lblCorreo.Location = new Point(84, 287);
            lblCorreo.Margin = new Padding(4, 0, 4, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(83, 38);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblTel
            // 
            lblTel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTel.ForeColor = SystemColors.ControlLightLight;
            lblTel.Location = new Point(397, 290);
            lblTel.Margin = new Padding(4, 0, 4, 0);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(91, 35);
            lblTel.TabIndex = 4;
            lblTel.Text = "Teléfono:";
            // 
            // lblPassHash
            // 
            lblPassHash.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassHash.ForeColor = SystemColors.ControlLightLight;
            lblPassHash.Location = new Point(84, 163);
            lblPassHash.Margin = new Padding(4, 0, 4, 0);
            lblPassHash.Name = "lblPassHash";
            lblPassHash.Size = new Size(116, 38);
            lblPassHash.TabIndex = 5;
            lblPassHash.Text = "Contraseña:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Red;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(82, 641);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(143, 47);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(397, 167);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(187, 38);
            label1.TabIndex = 16;
            label1.Text = "Confirmar Contraseña:";
            // 
            // txtPassHashConfirm
            // 
            txtPassHashConfirm.Location = new Point(397, 208);
            txtPassHashConfirm.Margin = new Padding(4, 5, 4, 5);
            txtPassHashConfirm.MaxLength = 50;
            txtPassHashConfirm.Name = "txtPassHashConfirm";
            txtPassHashConfirm.Size = new Size(284, 31);
            txtPassHashConfirm.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(84, 561);
            cmbEstado.Margin = new Padding(4, 5, 4, 5);
            cmbEstado.MaxLength = 7;
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(284, 33);
            cmbEstado.TabIndex = 13;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = SystemColors.ControlLightLight;
            lblEstado.Location = new Point(84, 518);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(143, 38);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // lblPin
            // 
            lblPin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPin.ForeColor = SystemColors.ControlLightLight;
            lblPin.Location = new Point(397, 407);
            lblPin.Margin = new Padding(4, 0, 4, 0);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(83, 38);
            lblPin.TabIndex = 17;
            lblPin.Text = "Pin:";
            // 
            // txtPin
            // 
            txtPin.Location = new Point(397, 450);
            txtPin.Margin = new Padding(4, 5, 4, 5);
            txtPin.MaxLength = 6;
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(284, 31);
            txtPin.TabIndex = 18;
            // 
            // AgregarResidente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(757, 720);
            Controls.Add(txtPin);
            Controls.Add(lblPin);
            Controls.Add(label1);
            Controls.Add(txtPassHashConfirm);
            Controls.Add(btnLimpiar);
            Controls.Add(lblNombres);
            Controls.Add(lblApellidos);
            Controls.Add(lblDocID);
            Controls.Add(lblCorreo);
            Controls.Add(lblTel);
            Controls.Add(lblPassHash);
            Controls.Add(lblEstado);
            Controls.Add(txtNombres);
            Controls.Add(txtApellidos);
            Controls.Add(txtDocID);
            Controls.Add(txtCorreo);
            Controls.Add(txtTel);
            Controls.Add(txtPassHash);
            Controls.Add(cmbEstado);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AgregarResidente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Residente";
            Load += AgregarResidente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Controles
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtDocID;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPassHash;
        private System.Windows.Forms.Button btnGuardar;

        // Labels
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblPassHash;



        private Button btnLimpiar;
        private Label label1;
        private TextBox txtPassHashConfirm;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private Label lblPin;
        private TextBox txtPin;
    }
}
