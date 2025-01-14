namespace Seminario_Proyecto_II.Forms.ResidentesRelacionados
{
    partial class VerPersonasRelacionadas
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.DataGridView dgvPersonasRelacionadas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;

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
            dgvPersonasRelacionadas = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonasRelacionadas).BeginInit();
            SuspendLayout();
            // 
            // dgvPersonasRelacionadas
            // 
            dgvPersonasRelacionadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonasRelacionadas.Location = new Point(10, 38);
            dgvPersonasRelacionadas.Margin = new Padding(3, 2, 3, 2);
            dgvPersonasRelacionadas.Name = "dgvPersonasRelacionadas";
            dgvPersonasRelacionadas.RowHeadersWidth = 51;
            dgvPersonasRelacionadas.RowTemplate.Height = 29;
            dgvPersonasRelacionadas.Size = new Size(852, 326);
            dgvPersonasRelacionadas.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(64, 9);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.MaxLength = 150;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre o DocID";
            txtBuscar.Size = new Size(232, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = SystemColors.ControlLightLight;
            lblBuscar.Location = new Point(10, 11);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(47, 15);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(796, 10);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(66, 22);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Green;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(711, 10);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(66, 22);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // VerPersonasRelacionadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(874, 375);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvPersonasRelacionadas);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "VerPersonasRelacionadas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Personas Relacionadas";
            Load += VerPersonasRelacionadas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersonasRelacionadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
