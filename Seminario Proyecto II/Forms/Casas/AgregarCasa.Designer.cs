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
            txtCalle.Location = new Point(84, 107);
            txtCalle.Margin = new Padding(4, 5, 4, 5);
            txtCalle.MaxLength = 100;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(427, 31);
            txtCalle.TabIndex = 0;
            // 
            // txtNumCasa
            // 
            txtNumCasa.Location = new Point(84, 232);
            txtNumCasa.Margin = new Padding(4, 5, 4, 5);
            txtNumCasa.MaxLength = 10;
            txtNumCasa.Name = "txtNumCasa";
            txtNumCasa.Size = new Size(158, 31);
            txtNumCasa.TabIndex = 1;
            // 
            // cmbTipo
            // 
            cmbTipo.Items.AddRange(new object[] { "Casa", "Apartamento" });
            cmbTipo.Location = new Point(326, 232);
            cmbTipo.Margin = new Padding(4, 5, 4, 5);
            cmbTipo.MaxLength = 20;
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(185, 33);
            cmbTipo.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(370, 395);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 47);
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
            btnLimpiar.Location = new Point(84, 395);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(143, 47);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // lblCalle
            // 
            lblCalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalle.ForeColor = SystemColors.ControlLightLight;
            lblCalle.Location = new Point(84, 63);
            lblCalle.Margin = new Padding(4, 0, 4, 0);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(143, 38);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle:";
            // 
            // lblNumCasa
            // 
            lblNumCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumCasa.ForeColor = SystemColors.ControlLightLight;
            lblNumCasa.Location = new Point(84, 190);
            lblNumCasa.Margin = new Padding(4, 0, 4, 0);
            lblNumCasa.Name = "lblNumCasa";
            lblNumCasa.Size = new Size(197, 38);
            lblNumCasa.TabIndex = 1;
            lblNumCasa.Text = "Número de Casa:";
            // 
            // lblTipo
            // 
            lblTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipo.ForeColor = SystemColors.ControlLightLight;
            lblTipo.Location = new Point(326, 188);
            lblTipo.Margin = new Padding(4, 0, 4, 0);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(143, 38);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            // 
            // AgregarCasa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(600, 500);
            Controls.Add(lblCalle);
            Controls.Add(lblNumCasa);
            Controls.Add(lblTipo);
            Controls.Add(txtCalle);
            Controls.Add(txtNumCasa);
            Controls.Add(cmbTipo);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
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
