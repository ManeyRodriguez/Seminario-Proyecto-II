using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seminario_Proyecto_II.Data;
using Seminario_Proyecto_II.Data.Repositories;
using Seminario_Proyecto_II.Forms.Login;
using Seminario_Proyecto_II.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Seminario_Proyecto_II
{
    internal static class Program
    {
        /// <summary>
        /// Configuraci�n principal de la aplicaci�n.
        /// </summary>
        public static IConfigurationRoot Configuration { get; private set; }

        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                // Cargar configuraci�n desde appsettings.json
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Validar la cadena de conexi�n
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexi�n 'DefaultConnection' no est� configurada en appsettings.json.");
                }

                // Configuraci�n del contenedor de dependencias
                ServiceProvider = new ServiceCollection()
                    .AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString))
                    .AddScoped<IResidenteRepository, ResidenteRepository>()
                    .BuildServiceProvider();

                // Aplicar migraciones a la base de datos
                using (var scope = ServiceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();
                }

                // Inicializar la configuraci�n de la aplicaci�n de Windows Forms
                ApplicationConfiguration.Initialize();

                // Resolver el repositorio y pasar al formulario principal
                var residenteRepository = Program.ServiceProvider.GetRequiredService<IResidenteRepository>();
                var loginForm = new LoginForm(residenteRepository);

                
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurri� un error cr�tico al iniciar la aplicaci�n: {ex.Message}\n\nDetalles:\n{ex.StackTrace}",
                    "Error de inicializaci�n",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
