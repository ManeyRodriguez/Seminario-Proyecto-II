using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seminario_Proyecto_II.Data;
using Seminario_Proyecto_II.Forms.Login;
using Seminario_Proyecto_II.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using Seminario_Proyecto_II.Data.Interfaces;

namespace Seminario_Proyecto_II
{
    internal static class Program
    {
 
        public static IConfigurationRoot? Configuration { get; private set; }
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) 
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                    .Build();

                
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada en appsettings.json.");
                }

                ServiceProvider = new ServiceCollection()
                    .AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString))  
                    .AddScoped<IResidenteRepository,ResidenteRepository>()
                    .AddScoped<ICasaRepository, CasaRepository>()
                    .AddScoped<IAdministradorRepository, AdministradorRepository>()
                    .AddScoped<IPersonaRelacionadaRepository, PersonaRelacionadaRepository>()
                    .BuildServiceProvider();



             
                using (var scope = ServiceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();
                }

               
                ApplicationConfiguration.Initialize();

               
                var residenteRepository = Program.ServiceProvider.GetRequiredService<IResidenteRepository>();
                var casaRepository = Program.ServiceProvider.GetRequiredService<ICasaRepository>();
                var adminRepository = Program.ServiceProvider.GetRequiredService<IAdministradorRepository>();
                var personaRelacionadaRepository = Program.ServiceProvider.GetRequiredService<IPersonaRelacionadaRepository>();

               
                var loginForm = new LoginForm(residenteRepository, casaRepository, adminRepository, personaRelacionadaRepository);
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(
                    $"Ocurrió un error crítico al iniciar la aplicación: {ex.Message}\n\nDetalles:\n{ex.StackTrace}",
                    "Error de inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
