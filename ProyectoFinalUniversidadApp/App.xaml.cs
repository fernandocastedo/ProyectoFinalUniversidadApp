using System.Configuration;
using System.Data;
using System.Windows;

namespace ProyectoFinalUniversidadApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            var sc = new ServiceCollection();

            // conexión a tu BD
            const string cn = "Data Source=FERCASTEDO;Initial Catalog=UniversidadDB;Integrated Security=True";

            sc.AddSingleton<IMateriaRepository>(_ => new MateriaRepository(cn));
            sc.AddSingleton<IMateriaService, MateriaService>();

            Services = sc.BuildServiceProvider();
            base.OnStartup(e);
        }
    }

}
