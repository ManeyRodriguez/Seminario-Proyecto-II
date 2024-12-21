using Seminario_Proyecto_II.Data.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Residentes
{
    public partial class VerResidentes : Form
    {
        private BindingSource bindingSource = new BindingSource();

        private void VerResidentes_Load(object sender, EventArgs e)
        {
            // Cargamos los datos de los residentes, con solo las columnas necesarias
            var residentes = ObtenerResidentes();
            bindingSource.DataSource = residentes;

            // Asignamos el BindingSource al DataGridView
            dgvResidentes.DataSource = bindingSource;

            // Configurar las columnas que se mostrarán
            
            dgvResidentes.Columns["Nombres"].HeaderText = "Nombres";
            dgvResidentes.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvResidentes.Columns["Tel"].HeaderText = "Teléfono";
            dgvResidentes.Columns["Correo"].HeaderText = "Correo";
            dgvResidentes.Columns["Estado"].HeaderText = "Estado";

            dgvResidentes.Columns["DocID"].Visible = false;

            dgvResidentes.Columns["PassHash"].Visible = false;
            dgvResidentes.Columns["Fecha"].Visible = false;
            dgvResidentes.Columns["Estado"].Visible = false;
            dgvResidentes.Columns["Casas"].Visible = false;
            dgvResidentes.Columns["PersonasRelacionadas"].Visible = false;
            dgvResidentes.Columns["Notificaciones"].Visible = false;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text) && txtBuscar.Text.Length >= 3)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();
                // Filtrar buscando en Nombres + Apellidos, Tel y Correo
                var residentesFiltrados = ObtenerResidentes().Where(r =>
                    (r.Nombres + " " + r.Apellidos).ToLower().Contains(filtro) || // Concatenamos Nombres + Apellidos
                    r.Tel.ToLower().Contains(filtro) ||
                    r.Correo.ToLower().Contains(filtro)
                ).ToList();

                bindingSource.DataSource = new BindingList<Residente>(residentesFiltrados);
            }
            else
            {
                // Si no hay texto o el texto tiene menos de 3 caracteres, mostrar todos los residentes
                bindingSource.DataSource = ObtenerResidentes();
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar el filtro de búsqueda
            txtBuscar.Clear();
            bindingSource.RemoveFilter();
        }

        private void VerResidentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpiar el filtro y liberar recursos si es necesario
            bindingSource.RemoveFilter();
        }

        // Método para obtener los residentes (esto debe estar en el repositorio o servicio de datos)
        private static BindingList<Residente> ObtenerResidentes()
        {
            // Crear una lista de objetos Residente con solo los campos que deseas mostrar
            var residentes = new List<Residente>
            {
                new Residente { Nombres = "Juan", Apellidos = "Pérez", Tel = "123456789", Correo = "juan@example.com", Estado = "Activo" },
                new Residente { Nombres = "Ana", Apellidos = "Gómez", Tel = "987654321", Correo = "ana@example.com", Estado = "Inactivo" }
             };

            return new BindingList<Residente>(residentes);
        }


        private void InitializeComponent()
        {
            dgvResidentes = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnLimpiar = new Button();
            ((ISupportInitialize)dgvResidentes).BeginInit();
            SuspendLayout();
            // 
            // dgvResidentes
            // 
            dgvResidentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResidentes.Location = new Point(12, 50);
            dgvResidentes.Name = "dgvResidentes";
            dgvResidentes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvResidentes.Size = new Size(500, 300);
            dgvResidentes.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(73, 12);
            txtBuscar.MaxLength = 150;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre Residente";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
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
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Red;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(300, 12);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // VerResidentes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(530, 370);
            Controls.Add(btnLimpiar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvResidentes);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.DataGridView dgvResidentes;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
