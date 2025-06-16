using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using ProyectoFinalUniversidadApp.BLL;
using ProyectoFinalUniversidadApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinalUniversidadApp.Views
{
    /// <summary>
    /// Interaction logic for UC_ReportMateriasOfertadas.xaml
    /// </summary>
    public partial class UC_ReportMateriasOfertadas : System.Windows.Controls.UserControl
    {
        private readonly IMateriaService _svc;

        public UC_ReportMateriasOfertadas()
        {
            InitializeComponent();
            _svc = App.Services.GetRequiredService<IMateriaService>();
        }

        private async void UserControl_Loaded(object s, RoutedEventArgs e)
        {
            var filtro = new MateriasFiltro(101, 1, 2025, "I"); // valores de prueba
            var svc = App.Services.GetRequiredService<IMateriaService>();
            var datos = await svc.ObtenerOfertadasAsync(filtro);

            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportEmbeddedResource =
                "ProyectoFinalUniversidadApp.Reports.ReportMateriasOfertadas.rdlc";

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(
                new ReportDataSource("DataSetMateriasOfertadas", datos));

            reportViewer.RefreshReport();
        }
    }
}