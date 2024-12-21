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
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            lblNombres = new Label();
            lblApellidos = new Label();
            lblDocID = new Label();
            lblCorreo = new Label();
            lblTel = new Label();
            lblPassHash = new Label();
            lblEstado = new Label();
            btnLimpiar = new Button();
            label1 = new Label();
            txtPassHashConfirm = new TextBox();
            SuspendLayout();
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(59, 48);
            txtNombres.MaxLength = 50;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(200, 23);
            txtNombres.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(278, 48);
            txtApellidos.MaxLength = 50;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(200, 23);
            txtApellidos.TabIndex = 1;
            // 
            // txtDocID
            // 
            txtDocID.Location = new Point(59, 270);
            txtDocID.Name = "txtDocID";
            txtDocID.Size = new Size(200, 23);
            txtDocID.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(59, 198);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 23);
            txtCorreo.TabIndex = 4;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(278, 198);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(200, 23);
            txtTel.TabIndex = 5;
            // 
            // txtPassHash
            // 
            txtPassHash.Location = new Point(59, 123);
            txtPassHash.MaxLength = 50;
            txtPassHash.Name = "txtPassHash";
            txtPassHash.Size = new Size(200, 23);
            txtPassHash.TabIndex = 2;
            // 
            // cmbEstado
            // 
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(278, 270);
            cmbEstado.MaxLength = 7;
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 13;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(378, 322);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 28);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // lblNombres
            // 
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.ForeColor = SystemColors.ControlLightLight;
            lblNombres.Location = new Point(59, 22);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(58, 23);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";
            // 
            // lblApellidos
            // 
            lblApellidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellidos.ForeColor = SystemColors.ControlLightLight;
            lblApellidos.Location = new Point(278, 22);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(65, 23);
            lblApellidos.TabIndex = 1;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblDocID
            // 
            lblDocID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDocID.ForeColor = SystemColors.ControlLightLight;
            lblDocID.Location = new Point(59, 249);
            lblDocID.Name = "lblDocID";
            lblDocID.Size = new Size(163, 18);
            lblDocID.TabIndex = 2;
            lblDocID.Text = "Documento de Identidad:";
            // 
            // lblCorreo
            // 
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCorreo.ForeColor = SystemColors.ControlLightLight;
            lblCorreo.Location = new Point(59, 172);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(58, 23);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblTel
            // 
            lblTel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTel.ForeColor = SystemColors.ControlLightLight;
            lblTel.Location = new Point(278, 174);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(64, 21);
            lblTel.TabIndex = 4;
            lblTel.Text = "Teléfono:";
            // 
            // lblPassHash
            // 
            lblPassHash.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassHash.ForeColor = SystemColors.ControlLightLight;
            lblPassHash.Location = new Point(59, 98);
            lblPassHash.Name = "lblPassHash";
            lblPassHash.Size = new Size(81, 23);
            lblPassHash.TabIndex = 5;
            lblPassHash.Text = "Contraseña:";
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = SystemColors.ControlLightLight;
            lblEstado.Location = new Point(278, 244);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(100, 23);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Red;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(59, 322);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 28);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(278, 100);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 16;
            label1.Text = "Confirmar Contraseña:";
            // 
            // txtPassHashConfirm
            // 
            txtPassHashConfirm.Location = new Point(278, 125);
            txtPassHashConfirm.MaxLength = 50;
            txtPassHashConfirm.Name = "txtPassHashConfirm";
            txtPassHashConfirm.Size = new Size(200, 23);
            txtPassHashConfirm.TabIndex = 3;
            // 
            // AgregarResidente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(530, 371);
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
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;

        // Labels
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblPassHash;
        private System.Windows.Forms.Label lblEstado;



        private Button btnLimpiar;
        private Label label1;
        private TextBox txtPassHashConfirm;
    }
}
