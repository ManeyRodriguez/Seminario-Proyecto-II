using Seminario_Proyecto_II.Forms.Residentes; // Asegúrate de incluir este namespace
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblCreador;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem residentesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarResidenteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verResidentesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem casasyAccesosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCasaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCasasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHistorialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasRelacionadasMenuItem; // Nuevo item de menú
        private System.Windows.Forms.ToolStripMenuItem agregarPersonaRelacionadaMenuItem; // Opción para agregar persona relacionada
        private System.Windows.Forms.ToolStripMenuItem verPersonasRelacionadasMenuItem; // Opción para ver personas relacionadas
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDateTime;
        private System.Windows.Forms.Timer timerDateTime;

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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            residentesMenuItem = new ToolStripMenuItem();
            agregarResidenteMenuItem = new ToolStripMenuItem();
            verResidentesMenuItem = new ToolStripMenuItem();
            casasyAccesosMenuItem = new ToolStripMenuItem();
            agregarCasaMenuItem = new ToolStripMenuItem();
            verCasasMenuItem = new ToolStripMenuItem();
            historialMenuItem = new ToolStripMenuItem();
            verHistorialMenuItem = new ToolStripMenuItem();
            personasRelacionadasMenuItem = new ToolStripMenuItem();
            agregarPersonaRelacionadaMenuItem = new ToolStripMenuItem();
            verPersonasRelacionadasMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            panelMain = new Panel();
            lblCreador = new Label();
            labelTitle = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelDateTime = new ToolStripStatusLabel();
            timerDateTime = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.Items.AddRange(new ToolStripItem[] { residentesMenuItem, personasRelacionadasMenuItem, casasyAccesosMenuItem, historialMenuItem, exitMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // residentesMenuItem
            // 
            residentesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarResidenteMenuItem, verResidentesMenuItem });
            residentesMenuItem.Image = Properties.Resources.team;
            residentesMenuItem.Name = "residentesMenuItem";
            residentesMenuItem.Size = new Size(91, 21);
            residentesMenuItem.Text = "Residentes";
            // 
            // agregarResidenteMenuItem
            // 
            agregarResidenteMenuItem.Image = Properties.Resources.plus;
            agregarResidenteMenuItem.Name = "agregarResidenteMenuItem";
            agregarResidenteMenuItem.Size = new Size(180, 22);
            agregarResidenteMenuItem.Text = "Agregar Residente";
            agregarResidenteMenuItem.Click += agregarResidenteMenuItem_Click;
            // 
            // verResidentesMenuItem
            // 
            verResidentesMenuItem.Image = Properties.Resources.search;
            verResidentesMenuItem.Name = "verResidentesMenuItem";
            verResidentesMenuItem.Size = new Size(180, 22);
            verResidentesMenuItem.Text = "Ver Residentes";
            verResidentesMenuItem.Click += verResidentesMenuItem_Click;
            // 
            // casasyAccesosMenuItem
            // 
            casasyAccesosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarCasaMenuItem, verCasasMenuItem });
            casasyAccesosMenuItem.Image = Properties.Resources.home;
            casasyAccesosMenuItem.Name = "casasyAccesosMenuItem";
            casasyAccesosMenuItem.Size = new Size(120, 21);
            casasyAccesosMenuItem.Text = "Casas y Accesos";
            // 
            // agregarCasaMenuItem
            // 
            agregarCasaMenuItem.Image = Properties.Resources.plus;
            agregarCasaMenuItem.Name = "agregarCasaMenuItem";
            agregarCasaMenuItem.Size = new Size(144, 22);
            agregarCasaMenuItem.Text = "Agregar Casa";
            agregarCasaMenuItem.Click += agregarCasaMenuItem_Click_1;
            // 
            // verCasasMenuItem
            // 
            verCasasMenuItem.Image = Properties.Resources.search;
            verCasasMenuItem.Name = "verCasasMenuItem";
            verCasasMenuItem.Size = new Size(144, 22);
            verCasasMenuItem.Text = "Ver Casas";
            verCasasMenuItem.Click += verCasasMenuItem_Click;
            // 
            // historialMenuItem
            // 
            historialMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verHistorialMenuItem });
            historialMenuItem.Image = Properties.Resources.time_management;
            historialMenuItem.Name = "historialMenuItem";
            historialMenuItem.Size = new Size(79, 21);
            historialMenuItem.Text = "Historial";
            // 
            // verHistorialMenuItem
            // 
            verHistorialMenuItem.Image = Properties.Resources.search;
            verHistorialMenuItem.Name = "verHistorialMenuItem";
            verHistorialMenuItem.Size = new Size(199, 22);
            verHistorialMenuItem.Text = "Ver Historial de Accesos";
            // 
            // personasRelacionadasMenuItem
            // 
            personasRelacionadasMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarPersonaRelacionadaMenuItem, verPersonasRelacionadasMenuItem });
            personasRelacionadasMenuItem.Image = Properties.Resources.team;
            personasRelacionadasMenuItem.Name = "personasRelacionadasMenuItem";
            personasRelacionadasMenuItem.Size = new Size(154, 21);
            personasRelacionadasMenuItem.Text = "Personas Relacionadas";
            // 
            // agregarPersonaRelacionadaMenuItem
            // 
            agregarPersonaRelacionadaMenuItem.Image = Properties.Resources.plus;
            agregarPersonaRelacionadaMenuItem.Name = "agregarPersonaRelacionadaMenuItem";
            agregarPersonaRelacionadaMenuItem.Size = new Size(228, 22);
            agregarPersonaRelacionadaMenuItem.Text = "Agregar Persona Relacionada";
            agregarPersonaRelacionadaMenuItem.Click += agregarPersonaRelacionadaMenuItem_Click;
            // 
            // verPersonasRelacionadasMenuItem
            // 
            verPersonasRelacionadasMenuItem.Image = Properties.Resources.search;
            verPersonasRelacionadasMenuItem.Name = "verPersonasRelacionadasMenuItem";
            verPersonasRelacionadasMenuItem.Size = new Size(228, 22);
            verPersonasRelacionadasMenuItem.Text = "Ver Personas Relacionadas";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitMenuItem.BackgroundImageLayout = ImageLayout.Center;
            exitMenuItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitMenuItem.Image = Properties.Resources.logout;
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(63, 21);
            exitMenuItem.Text = "Salir";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(lblCreador);
            panelMain.Controls.Add(labelTitle);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 25);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(800, 403);
            panelMain.TabIndex = 1;
            // 
            // lblCreador
            // 
            lblCreador.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCreador.AutoSize = true;
            lblCreador.Location = new Point(496, 388);
            lblCreador.Name = "lblCreador";
            lblCreador.Size = new Size(301, 15);
            lblCreador.TabIndex = 1;
            lblCreador.Text = "Realizado por: Juan Manuel Rodriguez Perez | 100048277";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(184, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(349, 29);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Bienvenido al Sistema GMAR";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(34, 34, 34);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelDateTime });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDateTime
            // 
            toolStripStatusLabelDateTime.BackColor = Color.White;
            toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            toolStripStatusLabelDateTime.Size = new Size(109, 17);
            toolStripStatusLabelDateTime.Text = "Fecha y hora actual";
            // 
            // timerDateTime
            // 
            timerDateTime.Enabled = true;
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += timerDateTime_Tick;
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(panelMain);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GMAR - Gestión y Monitoreo de Acceso Residencial";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion




    }
}
