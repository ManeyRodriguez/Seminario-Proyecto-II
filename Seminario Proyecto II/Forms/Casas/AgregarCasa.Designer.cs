using System;
using System.Drawing;
using System.Windows.Forms;
using Seminario_Proyecto_II.Data.Models;

namespace Seminario_Proyecto_II.Forms.Casas
{
    partial class AgregarCasa 
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
            txtCalle = new TextBox();
            txtNumCasa = new TextBox();
            cmbTipo = new ComboBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            lblCalle = new Label();
            lblNumCasa = new Label();
            lblTipo = new Label();
            SuspendLayout();
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(59, 64);
            txtCalle.MaxLength = 100;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(300, 23);
            txtCalle.TabIndex = 0;
            // 
            // txtNumCasa
            // 
            txtNumCasa.Location = new Point(59, 139);
            txtNumCasa.MaxLength = 10;
            txtNumCasa.Name = "txtNumCasa";
            txtNumCasa.Size = new Size(112, 23);
            txtNumCasa.TabIndex = 1;
            // 
            // cmbTipo
            // 
            cmbTipo.Items.AddRange(new object[] { "Casa", "Apartamento" });
            cmbTipo.Location = new Point(228, 139);
            cmbTipo.MaxLength = 20;
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(131, 23);
            cmbTipo.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(259, 237);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 28);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Red;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(59, 237);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 28);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // lblCalle
            // 
            lblCalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalle.ForeColor = SystemColors.ControlLightLight;
            lblCalle.Location = new Point(59, 38);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(100, 23);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle:";
            // 
            // lblNumCasa
            // 
            lblNumCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumCasa.ForeColor = SystemColors.ControlLightLight;
            lblNumCasa.Location = new Point(59, 114);
            lblNumCasa.Name = "lblNumCasa";
            lblNumCasa.Size = new Size(100, 23);
            lblNumCasa.TabIndex = 1;
            lblNumCasa.Text = "Número de Casa:";
            // 
            // lblTipo
            // 
            lblTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipo.ForeColor = SystemColors.ControlLightLight;
            lblTipo.Location = new Point(228, 113);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(100, 23);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            // 
            // AgregarCasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(420, 300);
            Controls.Add(lblCalle);
            Controls.Add(lblNumCasa);
            Controls.Add(lblTipo);
            Controls.Add(txtCalle);
            Controls.Add(txtNumCasa);
            Controls.Add(cmbTipo);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarCasa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Casa";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox txtCalle;
        private TextBox txtNumCasa;
        private ComboBox cmbTipo;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Label lblCalle;
        private Label lblNumCasa;
        private Label lblTipo;
    }
}
