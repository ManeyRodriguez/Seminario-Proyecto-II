namespace Seminario_Proyecto_II.Forms.Casas
{
    partial class EditarCasa
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
            lblCalle = new Label();
            lblNumCasa = new Label();
            lblTipo = new Label();
            lblBuscarResidente = new Label();
            lblResidenteActual = new Label();
            txtCalle = new TextBox();
            txtNumCasa = new TextBox();
            cmbTipo = new ComboBox();
            btnGuardar = new Button();
            txtBuscarResidente = new TextBox();
            btnBuscarResidente = new Button();
            lstResidentes = new ListBox();
            SuspendLayout();
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalle.ForeColor = SystemColors.ControlLightLight;
            lblCalle.Location = new Point(95, 51);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(36, 15);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle:";
            // 
            // lblNumCasa
            // 
            lblNumCasa.AutoSize = true;
            lblNumCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumCasa.ForeColor = SystemColors.ControlLightLight;
            lblNumCasa.Location = new Point(95, 101);
            lblNumCasa.Name = "lblNumCasa";
            lblNumCasa.Size = new Size(100, 15);
            lblNumCasa.TabIndex = 1;
            lblNumCasa.Text = "Número de Casa:";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipo.ForeColor = SystemColors.ControlLightLight;
            lblTipo.Location = new Point(97, 158);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            // 
            // lblBuscarResidente
            // 
            lblBuscarResidente.AutoSize = true;
            lblBuscarResidente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscarResidente.ForeColor = SystemColors.ControlLightLight;
            lblBuscarResidente.Location = new Point(12, 224);
            lblBuscarResidente.Name = "lblBuscarResidente";
            lblBuscarResidente.Size = new Size(106, 15);
            lblBuscarResidente.TabIndex = 7;
            lblBuscarResidente.Text = "Buscar Residente:";
            // 
            // lblResidenteActual
            // 
            lblResidenteActual.AutoSize = true;
            lblResidenteActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResidenteActual.ForeColor = SystemColors.ControlLightLight;
            lblResidenteActual.Location = new Point(12, 19);
            lblResidenteActual.Name = "lblResidenteActual";
            lblResidenteActual.Size = new Size(112, 15);
            lblResidenteActual.TabIndex = 11;
            lblResidenteActual.Text = "Residente Actual: -";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(95, 69);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(200, 23);
            txtCalle.TabIndex = 3;
            // 
            // txtNumCasa
            // 
            txtNumCasa.Location = new Point(95, 119);
            txtNumCasa.Name = "txtNumCasa";
            txtNumCasa.Size = new Size(200, 23);
            txtNumCasa.TabIndex = 4;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Casa", "Apartamento" });
            cmbTipo.Location = new Point(95, 176);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 23);
            cmbTipo.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(140, 572);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // txtBuscarResidente
            // 
            txtBuscarResidente.Location = new Point(12, 242);
            txtBuscarResidente.Name = "txtBuscarResidente";
            txtBuscarResidente.Size = new Size(247, 23);
            txtBuscarResidente.TabIndex = 8;
            txtBuscarResidente.TextChanged += txtBuscarResidente_TextChanged_1;
            // 
            // btnBuscarResidente
            // 
            btnBuscarResidente.BackColor = SystemColors.Highlight;
            btnBuscarResidente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarResidente.ForeColor = SystemColors.ControlLightLight;
            btnBuscarResidente.Location = new Point(265, 242);
            btnBuscarResidente.Name = "btnBuscarResidente";
            btnBuscarResidente.Size = new Size(100, 24);
            btnBuscarResidente.TabIndex = 9;
            btnBuscarResidente.Text = "Buscar";
            btnBuscarResidente.UseVisualStyleBackColor = false;
            btnBuscarResidente.Click += BtnBuscarResidente_Click;
            // 
            // lstResidentes
            // 
            lstResidentes.FormattingEnabled = true;
            lstResidentes.ItemHeight = 15;
            lstResidentes.Location = new Point(12, 277);
            lstResidentes.Name = "lstResidentes";
            lstResidentes.Size = new Size(353, 289);
            lstResidentes.TabIndex = 10;
            lstResidentes.SelectedIndexChanged += LstResidentes_SelectedIndexChanged;
            // 
            // EditarCasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(377, 629);
            Controls.Add(lblCalle);
            Controls.Add(txtCalle);
            Controls.Add(lblNumCasa);
            Controls.Add(txtNumCasa);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipo);
            Controls.Add(btnGuardar);
            Controls.Add(lblBuscarResidente);
            Controls.Add(txtBuscarResidente);
            Controls.Add(btnBuscarResidente);
            Controls.Add(lstResidentes);
            Controls.Add(lblResidenteActual);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarCasa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Casa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCalle;
        private Label lblNumCasa;
        private Label lblTipo;
        private Label lblBuscarResidente;
        private Label lblResidenteActual;  // Nueva etiqueta para el residente actual
        private TextBox txtCalle;
        private TextBox txtNumCasa;
        private ComboBox cmbTipo;
        private Button btnGuardar;
        private TextBox txtBuscarResidente;
        private Button btnBuscarResidente;
        private ListBox lstResidentes;
    }
}
