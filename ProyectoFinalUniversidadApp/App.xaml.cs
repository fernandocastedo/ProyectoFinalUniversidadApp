using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;  // paquete agregado en el paso 1
using ProyectoFinalUniversidadApp.BLL;
using ProyectoFinalUniversidadApp.DAL;

namespace ProyectoFinalUniversidadApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            var sc = new ServiceCollection();

            // conexión a tu BD
            const string cn = "Data Source=FERCASTEDO;Initial Catalog=UniversidadDB2;Integrated Security=True";

            sc.AddSingleton<IMateriaRepository>(_ => new MateriaRepository(cn));
            sc.AddSingleton<IMateriaService, MateriaService>();

            Services = sc.BuildServiceProvider();
            base.OnStartup(e);
        }
    }

}
