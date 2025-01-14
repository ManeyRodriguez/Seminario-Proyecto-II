using Seminario_Proyecto_II.Data.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class VerResidentes : Form
    {


        // Métodos de inicialización de botones (para eliminar y editar)
        private void InitializeComponent()
        {
            dgvResidentes = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            ((ISupportInitialize)dgvResidentes).BeginInit();
            SuspendLayout();
            // 
            // dgvResidentes
            // 
            dgvResidentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResidentes.Location = new Point(17, 83);
            dgvResidentes.Margin = new Padding(4, 5, 4, 5);
            dgvResidentes.Name = "dgvResidentes";
            dgvResidentes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvResidentes.Size = new Size(939, 500);
            dgvResidentes.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(104, 28);
            txtBuscar.Margin = new Padding(4, 5, 4, 5);
            txtBuscar.MaxLength = 150;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre Residente";
            txtBuscar.Size = new Size(375, 31);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += BtnBuscar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = SystemColors.ControlLightLight;
            lblBuscar.Location = new Point(17, 33);
            lblBuscar.Margin = new Padding(4, 0, 4, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(75, 25);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(849, 25);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(107, 38);
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
            btnEditar.Location = new Point(722, 25);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 38);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // VerResidentes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(976, 617);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvResidentes);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VerResidentes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Residentes";
            FormClosing += VerResidentes_FormClosing;
            Load += VerResidentes_Load;
            ((ISupportInitialize)dgvResidentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        // Controles
        private DataGridView dgvResidentes;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
    }
}
