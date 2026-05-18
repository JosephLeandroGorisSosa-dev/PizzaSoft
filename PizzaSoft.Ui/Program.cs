using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaSoft.Data.Context; // Asegúrate de que esta ruta sea correcta tras el Scaffold

using PizzaSoft.Ui;
using PizzaSoft.Ui.Services;
using System.Configuration;

namespace PizzaSoft.Ui
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            // Iniciamos con tu formulario principal (asegúrate de que el nombre sea Form1 o el que definiste)
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {

            string connectionString = ConfigurationManager
                .ConnectionStrings["PizzaLeoneDb"].ConnectionString;

            services.AddDbContext<PizzaLeoneDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            // 2. Registro de Formularios y Controles de Usuario (UI)
            services.AddTransient<Form1>();
            services.AddTransient<PizzaSoft.Ui.UCNuevaVenta.UCNuevaVenta>();
            services.AddTransient<PizzaSoft.Ui.UCGestionProductos.UCGestionProductos>();
            services.AddTransient<PizzaSoft.Ui.UCGestionCategorias>();
            services.AddTransient<PizzaSoft.Ui.UCGestionClientes.UCGestionClientes>();
            services.AddTransient<PizzaSoft.Ui.UCHistorialVentas.UCHistorialVentas>();

            // 3. Registro de Servicios de Negocio
            services.AddTransient<VentaService>();
            services.AddTransient<ProductoService>();
            services.AddTransient<CategoriaService>();
            services.AddTransient<ClienteService>();
        }
    }
}