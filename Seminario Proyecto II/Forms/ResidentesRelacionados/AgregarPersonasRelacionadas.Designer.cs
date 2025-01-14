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
            lblCasaSelecc = new Label();
            dtpFechaExp = new DateTimePicker();
            dtpTiempoExp = new DateTimePicker();
            lblFechaExp = new Label();
            txtPin = new TextBox();
            lblPin = new Label();
            cmbEstado = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResultadosBusqueda).BeginInit();
            SuspendLayout();
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(40, 77);
            txtNombres.Margin = new Padding(4, 5, 4, 5);
            txtNombres.MaxLength = 50;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(358, 31);
            txtNombres.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(471, 77);
            txtApellidos.Margin = new Padding(4, 5, 4, 5);
            txtApellidos.MaxLength = 50;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(358, 31);
            txtApellidos.TabIndex = 1;
            // 
            // txtDocID
            // 
            txtDocID.Location = new Point(40, 173);
            txtDocID.Margin = new Padding(4, 5, 4, 5);
            txtDocID.Name = "txtDocID";
            txtDocID.Size = new Size(358, 31);
            txtDocID.TabIndex = 2;
            // 
            // cmbTipoPersona
            // 
            cmbTipoPersona.Items.AddRange(new object[] { "Familiar", "Invitado", "Trabajador" });
            cmbTipoPersona.Location = new Point(471, 173);
            cmbTipoPersona.Margin = new Padding(4, 5, 4, 5);
            cmbTipoPersona.Name = "cmbTipoPersona";
            cmbTipoPersona.Size = new Size(358, 33);
            cmbTipoPersona.TabIndex = 4;
            cmbTipoPersona.SelectedIndexChanged += cmbTipoPersona_SelectedIndexChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(840, 961);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 47);
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
            btnLimpiar.Location = new Point(40, 961);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(143, 47);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(40, 270);
            txtTelefono.Margin = new Padding(4, 5, 4, 5);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(358, 31);
            txtTelefono.TabIndex = 7;
            // 
            // lblNombres
            // 
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.ForeColor = SystemColors.ControlLightLight;
            lblNombres.Location = new Point(40, 33);
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
            lblApellidos.Location = new Point(471, 33);
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
            lblDocID.Location = new Point(40, 130);
            lblDocID.Margin = new Padding(4, 0, 4, 0);
            lblDocID.Name = "lblDocID";
            lblDocID.Size = new Size(233, 38);
            lblDocID.TabIndex = 2;
            lblDocID.Text = "Documento de Identidad:";
            // 
            // lblTipoPersona
            // 
            lblTipoPersona.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoPersona.ForeColor = SystemColors.ControlLightLight;
            lblTipoPersona.Location = new Point(471, 130);
            lblTipoPersona.Margin = new Padding(4, 0, 4, 0);
            lblTipoPersona.Name = "lblTipoPersona";
            lblTipoPersona.Size = new Size(143, 38);
            lblTipoPersona.TabIndex = 4;
            lblTipoPersona.Text = "Tipo de Persona:";
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = SystemColors.ControlLightLight;
            lblTelefono.Location = new Point(40, 227);
            lblTelefono.Margin = new Padding(4, 0, 4, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(143, 38);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblBuscarCasa
            // 
            lblBuscarCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscarCasa.ForeColor = SystemColors.ControlLightLight;
            lblBuscarCasa.Location = new Point(471, 227);
            lblBuscarCasa.Margin = new Padding(4, 0, 4, 0);
            lblBuscarCasa.Name = "lblBuscarCasa";
            lblBuscarCasa.Size = new Size(143, 38);
            lblBuscarCasa.TabIndex = 8;
            lblBuscarCasa.Text = "Buscar Casa:";
            // 
            // txtBuscarCasa
            // 
            txtBuscarCasa.Location = new Point(471, 270);
            txtBuscarCasa.Margin = new Padding(4, 5, 4, 5);
            txtBuscarCasa.MaxLength = 150;
            txtBuscarCasa.Name = "txtBuscarCasa";
            txtBuscarCasa.PlaceholderText = "Direccion, # casa , Residente";
            txtBuscarCasa.Size = new Size(358, 31);
            txtBuscarCasa.TabIndex = 9;
            // 
            // btnBuscarCasa
            // 
            btnBuscarCasa.BackColor = SystemColors.Highlight;
            btnBuscarCasa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnBuscarCasa.ForeColor = SystemColors.ControlLightLight;
            btnBuscarCasa.Location = new Point(853, 263);
            btnBuscarCasa.Margin = new Padding(4, 5, 4, 5);
            btnBuscarCasa.Name = "btnBuscarCasa";
            btnBuscarCasa.Size = new Size(114, 47);
            btnBuscarCasa.TabIndex = 10;
            btnBuscarCasa.Text = "Buscar";
            btnBuscarCasa.UseVisualStyleBackColor = false;
            btnBuscarCasa.MouseClick += btnBuscarCasa_MouseClick;
            // 
            // dgvResultadosBusqueda
            // 
            dgvResultadosBusqueda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvResultadosBusqueda.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvResultadosBusqueda.ColumnHeadersHeight = 34;
            dgvResultadosBusqueda.Location = new Point(40, 587);
            dgvResultadosBusqueda.Margin = new Padding(4, 5, 4, 5);
            dgvResultadosBusqueda.MultiSelect = false;
            dgvResultadosBusqueda.Name = "dgvResultadosBusqueda";
            dgvResultadosBusqueda.RowHeadersWidth = 62;
            dgvResultadosBusqueda.Size = new Size(943, 349);
            dgvResultadosBusqueda.TabIndex = 11;
            dgvResultadosBusqueda.CellClick += dgvResultadosBusqueda_CellClick_1;
            // 
            // lblCasaSelecc
            // 
            lblCasaSelecc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCasaSelecc.ForeColor = SystemColors.ControlLightLight;
            lblCasaSelecc.Location = new Point(40, 544);
            lblCasaSelecc.Margin = new Padding(4, 0, 4, 0);
            lblCasaSelecc.Name = "lblCasaSelecc";
            lblCasaSelecc.Size = new Size(786, 38);
            lblCasaSelecc.TabIndex = 13;
            lblCasaSelecc.Text = "Casa Seleccionada: ";
            // 
            // dtpFechaExp
            // 
            dtpFechaExp.CustomFormat = "MM/dd/yyyy";
            dtpFechaExp.Format = DateTimePickerFormat.Custom;
            dtpFechaExp.Location = new Point(471, 374);
            dtpFechaExp.Name = "dtpFechaExp";
            dtpFechaExp.Size = new Size(355, 31);
            dtpFechaExp.TabIndex = 14;
            dtpFechaExp.ValueChanged += dtpFechaExp_ValueChanged;
            // 
            // dtpTiempoExp
            // 
            dtpTiempoExp.CustomFormat = "hh:mm tt";
            dtpTiempoExp.Format = DateTimePickerFormat.Custom;
            dtpTiempoExp.Location = new Point(471, 424);
            dtpTiempoExp.Name = "dtpTiempoExp";
            dtpTiempoExp.ShowUpDown = true;
            dtpTiempoExp.Size = new Size(355, 31);
            dtpTiempoExp.TabIndex = 15;
            dtpTiempoExp.ValueChanged += dtpTiempoExp_ValueChanged;
            // 
            // lblFechaExp
            // 
            lblFechaExp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaExp.ForeColor = SystemColors.ControlLightLight;
            lblFechaExp.Location = new Point(471, 333);
            lblFechaExp.Margin = new Padding(4, 0, 4, 0);
            lblFechaExp.Name = "lblFechaExp";
            lblFechaExp.Size = new Size(300, 38);
            lblFechaExp.TabIndex = 16;
            lblFechaExp.Text = "Fecha Expiración:";
            // 
            // txtPin
            // 
            txtPin.Location = new Point(40, 376);
            txtPin.Margin = new Padding(4, 5, 4, 5);
            txtPin.MaxLength = 50;
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(358, 31);
            txtPin.TabIndex = 17;
            // 
            // lblPin
            // 
            lblPin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPin.ForeColor = SystemColors.ControlLightLight;
            lblPin.Location = new Point(40, 332);
            lblPin.Margin = new Padding(4, 0, 4, 0);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(83, 38);
            lblPin.TabIndex = 18;
            lblPin.Text = "Pin:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(40, 479);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(358, 33);
            cmbEstado.TabIndex = 19;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(40, 438);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 38);
            label1.TabIndex = 20;
            label1.Text = "Estado:";
            // 
            // AgregarPersonasRelacionadas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(1010, 1045);
            Controls.Add(label1);
            Controls.Add(cmbEstado);
            Controls.Add(txtPin);
            Controls.Add(lblPin);
            Controls.Add(lblFechaExp);
            Controls.Add(dtpTiempoExp);
            Controls.Add(dtpFechaExp);
            Controls.Add(lblCasaSelecc);
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
            Margin = new Padding(4, 5, 4, 5);
            Name = "AgregarPersonasRelacionadas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Persona Relacionada";
            Load += AgregarPersonasRelacionadas_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvResultadosBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblPin;
        private Label lblCasaSelecc;
        private DateTimePicker dtpFechaExp;
        private DateTimePicker dtpTiempoExp;
        private Label lblFechaExp;
        private TextBox txtPin;
        private ComboBox cmbEstado;
        private Label label1;
    }
}
