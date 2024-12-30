using Seminario_Proyecto_II.Data.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Casas
{
    public partial class VerCasas : Form
    {
        // Métodos de inicialización de botones (para eliminar y editar)
        private void InitializeComponent()
        {
            dgvCasas = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            ((ISupportInitialize)dgvCasas).BeginInit();
            SuspendLayout();
            // 
            // dgvCasas
            // 
            dgvCasas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCasas.Location = new Point(12, 50);
            dgvCasas.Name = "dgvCasas";
            dgvCasas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvCasas.Size = new Size(505, 300);
            dgvCasas.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(73, 12);
            txtBuscar.MaxLength = 150;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Calle o Número de Casa";
            txtBuscar.Size = new Size(220, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += BtnBuscar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = SystemColors.ControlLightLight;
            lblBuscar.Location = new Point(12, 15);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(47, 15);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(444, 11);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Green;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(352, 11);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // VerCasas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(529, 370);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvCasas);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "VerCasas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Casas";
            FormClosing += VerCasas_FormClosing;
            Load += VerCasas_Load;
            ((ISupportInitialize)dgvCasas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Controles
        private DataGridView dgvCasas;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Button btnEliminar;
        private Button btnEditar;


    }
}
