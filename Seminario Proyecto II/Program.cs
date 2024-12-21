using Microsoft.EntityFrameworkCore;
using Seminario_Proyecto_II.Data;
using System;
using System.Windows.Forms;

using Seminario_Proyecto_II.Forms.Login;
using Seminario_Proyecto_II.Forms;

namespace Seminario_Proyecto_II
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Aplicar migraciones pendientes
            using (var dbContext = new AppDbContextFactory().CreateDbContext(null))
            {
                dbContext.Database.Migrate();
            }

            // Inicializar la aplicación de Windows Forms
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
