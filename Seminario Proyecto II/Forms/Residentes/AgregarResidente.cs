using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class AgregarResidente : Form
    {
        public AgregarResidente()
        {
            InitializeComponent();
        }

        private void AgregarResidente_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            txtNombres.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
            cmbEstado.SelectedIndex = 0;
        }

        // Evento Click del botón Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
                string.IsNullOrEmpty(txtDocID.Text) || string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtPassHash.Text) || string.IsNullOrEmpty(txtPassHashConfirm.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Residente nuevoResidente = new Residente
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                DocID = txtDocID.Text,
                Correo = txtCorreo.Text,
                Tel = txtTel.Text,
                PassHash = txtPassHash.Text,
                Estado = cmbEstado.SelectedItem.ToString(),
            };


            MessageBox.Show("Residente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDocID.Clear();
            txtCorreo.Clear();
            txtTel.Clear();
            txtPassHash.Clear();
            cmbEstado.SelectedIndex = 0;
        }
    }
}
