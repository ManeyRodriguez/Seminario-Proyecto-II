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

namespace Seminario_Proyecto_II
{
    internal static class Program
    {
        // Propiedad estática para manejar la configuración y el contenedor de servicios
        public static IConfigurationRoot Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                // Cargar configuración desde appsettings.json
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Establece la ruta base para buscar el archivo JSON
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Carga el archivo JSON de configuración
                    .Build();

                // Validar que la cadena de conexión esté configurada correctamente
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada en appsettings.json.");
                }

                ServiceProvider = new ServiceCollection()
                    .AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString))  // Registra el DbContext
                    .AddScoped<IResidenteRepository,ResidenteRepository>()
                    .AddScoped<ICasaRepository, CasaRepository>()
                    .AddScoped<IAdministradorRepository, AdministradorRepository>()
                    .AddScoped<IPersonaRelacionadaRepository, PersonaRelacionadaRepository>()
                    .BuildServiceProvider();



                // Aplicar las migraciones de la base de datos al iniciar la aplicación
                using (var scope = ServiceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate(); // Aplica migraciones pendientes
                }

                // Inicializa la configuración de la aplicación de Windows Forms
                ApplicationConfiguration.Initialize();

                // Resolver el repositorio genérico para la entidad Residente
                var residenteRepository = Program.ServiceProvider.GetRequiredService<IResidenteRepository>();
                var casaRepository = Program.ServiceProvider.GetRequiredService<ICasaRepository>();
                var adminRepository = Program.ServiceProvider.GetRequiredService<IAdministradorRepository>();
                var personaRelacionadaRepository = Program.ServiceProvider.GetRequiredService<IPersonaRelacionadaRepository>();

                // Crear y mostrar el formulario de login
                var loginForm = new LoginForm(residenteRepository, casaRepository, adminRepository, personaRelacionadaRepository);
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si algo falla durante la inicialización
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
