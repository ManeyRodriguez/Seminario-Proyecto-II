namespace Seminario_Proyecto_II.Forms.Residentes
{
    partial class AgregarPersonasRelacionadas
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtDocID;
        private ComboBox cmbTipoPersona;
        private Button btnGuardar;
        private Button btnLimpiar;
        private TextBox txtTelefono;
        private Label lblNombres;
        private Label lblApellidos;
        private Label lblDocID;
        private Label lblTipoPersona;
        private Label lblTelefono;
        private Label lblBuscarCasa;
        private TextBox txtBuscarCasa;
        private Button btnBuscarCasa;
        private DataGridView dgvResultadosBusqueda;

        private void InitializeComponent()
        {
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtDocID = new TextBox();
            cmbTipoPersona = new ComboBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            txtTelefono = new TextBox();
            lblNombres = new Label();
            lblApellidos = new Label();
            lblDocID = new Label();
            lblTipoPersona = new Label();
            lblTelefono = new Label();
            lblBuscarCasa = new Label();
            txtBuscarCasa = new TextBox();
            btnBuscarCasa = new Button();
            dgvResultadosBusqueda = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResultadosBusqueda).BeginInit();
            SuspendLayout();
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(28, 46);
            txtNombres.MaxLength = 50;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(252, 23);
            txtNombres.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(330, 46);
            txtApellidos.MaxLength = 50;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(252, 23);
            txtApellidos.TabIndex = 1;
            // 
            // txtDocID
            // 
            txtDocID.Location = new Point(28, 104);
            txtDocID.Name = "txtDocID";
            txtDocID.Size = new Size(252, 23);
            txtDocID.TabIndex = 2;
            // 
            // cmbTipoPersona
            // 
            cmbTipoPersona.Items.AddRange(new object[] { "Familiar", "Invitado", "Trabajador" });
            cmbTipoPersona.Location = new Point(330, 104);
            cmbTipoPersona.Name = "cmbTipoPersona";
            cmbTipoPersona.Size = new Size(252, 23);
            cmbTipoPersona.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(588, 504);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 28);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Red;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(28, 504);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 28);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(28, 162);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(252, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblNombres
            // 
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.ForeColor = SystemColors.ControlLightLight;
            lblNombres.Location = new Point(28, 20);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(58, 23);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";
            // 
            // lblApellidos
            // 
            lblApellidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellidos.ForeColor = SystemColors.ControlLightLight;
            lblApellidos.Location = new Point(330, 20);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(65, 23);
            lblApellidos.TabIndex = 1;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblDocID
            // 
            lblDocID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDocID.ForeColor = SystemColors.ControlLightLight;
            lblDocID.Location = new Point(28, 78);
            lblDocID.Name = "lblDocID";
            lblDocID.Size = new Size(163, 23);
            lblDocID.TabIndex = 2;
            lblDocID.Text = "Documento de Identidad:";
            // 
            // lblTipoPersona
            // 
            lblTipoPersona.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoPersona.ForeColor = SystemColors.ControlLightLight;
            lblTipoPersona.Location = new Point(330, 78);
            lblTipoPersona.Name = "lblTipoPersona";
            lblTipoPersona.Size = new Size(100, 23);
            lblTipoPersona.TabIndex = 4;
            lblTipoPersona.Text = "Tipo de Persona:";
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = SystemColors.ControlLightLight;
            lblTelefono.Location = new Point(28, 136);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(100, 23);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblBuscarCasa
            // 
            lblBuscarCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscarCasa.ForeColor = SystemColors.ControlLightLight;
            lblBuscarCasa.Location = new Point(330, 136);
            lblBuscarCasa.Name = "lblBuscarCasa";
            lblBuscarCasa.Size = new Size(100, 23);
            lblBuscarCasa.TabIndex = 8;
            lblBuscarCasa.Text = "Buscar Casa:";
            // 
            // txtBuscarCasa
            // 
            txtBuscarCasa.Location = new Point(330, 162);
            txtBuscarCasa.MaxLength = 150;
            txtBuscarCasa.Name = "txtBuscarCasa";
            txtBuscarCasa.PlaceholderText = "Direccion, # casa , Residente";
            txtBuscarCasa.Size = new Size(252, 23);
            txtBuscarCasa.TabIndex = 9;
            // 
            // btnBuscarCasa
            // 
            btnBuscarCasa.BackColor = SystemColors.Highlight;
            btnBuscarCasa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnBuscarCasa.ForeColor = SystemColors.ControlLightLight;
            btnBuscarCasa.Location = new Point(597, 158);
            btnBuscarCasa.Name = "btnBuscarCasa";
            btnBuscarCasa.Size = new Size(80, 28);
            btnBuscarCasa.TabIndex = 10;
            btnBuscarCasa.Text = "Buscar";
            btnBuscarCasa.UseVisualStyleBackColor = false;
            btnBuscarCasa.MouseClick += btnBuscarCasa_MouseClick;
            // 
            // dgvResultadosBusqueda
            // 
            dgvResultadosBusqueda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvResultadosBusqueda.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvResultadosBusqueda.Location = new Point(28, 246);
            dgvResultadosBusqueda.MultiSelect = false;
            dgvResultadosBusqueda.Name = "dgvResultadosBusqueda";
            dgvResultadosBusqueda.Size = new Size(660, 243);
            dgvResultadosBusqueda.TabIndex = 11;
            dgvResultadosBusqueda.CellClick += dgvResultadosBusqueda_CellClick_1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(28, 220);
            label1.Name = "label1";
            label1.Size = new Size(550, 23);
            label1.TabIndex = 12;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(28, 197);
            label2.Name = "label2";
            label2.Size = new Size(550, 23);
            label2.TabIndex = 13;
            label2.Text = "Casa Seleccionada: ";
            // 
            // AgregarPersonasRelacionadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(700, 552);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombres);
            Controls.Add(txtApellidos);
            Controls.Add(txtDocID);
            Controls.Add(cmbTipoPersona);
            Controls.Add(txtTelefono);
            Controls.Add(txtBuscarCasa);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscarCasa);
            Controls.Add(lblNombres);
            Controls.Add(lblApellidos);
            Controls.Add(lblDocID);
            Controls.Add(lblTipoPersona);
            Controls.Add(lblTelefono);
            Controls.Add(lblBuscarCasa);
            Controls.Add(dgvResultadosBusqueda);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarPersonasRelacionadas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Persona Relacionada";
            ((System.ComponentModel.ISupportInitialize)dgvResultadosBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
    }
}
