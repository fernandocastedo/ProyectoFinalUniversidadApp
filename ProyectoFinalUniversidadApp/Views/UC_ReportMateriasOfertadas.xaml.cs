using Microsoft.Reporting.WinForms;
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
    public partial class UC_ReportMateriasOfertadas : UserControl
    {
        public UC_ReportMateriasOfertadas()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object s, RoutedEventArgs e)
        {
            // 1. Obtener los datos desde la capa BLL (tu SP ya existe)
            var servicio = App.Current.Services.GetRequiredService<IMateriaService>();
            var datos = await servicio.GetMateriasOfertadasAsync(
                            codCarrera, codPlan, anio, semestre);

            // 2. Configurar ReportViewer
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportEmbeddedResource =
                "UniversidadApp.Wpf.Reports.ReportMateriasOfertadas.rdlc";

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(
                new ReportDataSource("DataSetMateriasOfertadas", datos));

            // 3. Parámetros opcionales
            reportViewer.LocalReport.SetParameters(new[]
            {
            new ReportParameter("pCarrera", codCarrera.ToString()),
            new ReportParameter("pPlan", codPlan.ToString())
        });

            reportViewer.RefreshReport();
        }
    }
}
