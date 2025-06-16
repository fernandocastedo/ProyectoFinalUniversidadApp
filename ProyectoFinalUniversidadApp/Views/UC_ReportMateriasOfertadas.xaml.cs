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
        private readonly IMateriaService _svc;

        public UC_ReportMateriasOfertadas()
        {
            InitializeComponent();
            _svc = App.Services.GetRequiredService<IMateriaService>();
        }

        private async void UserControl_Loaded(object s, RoutedEventArgs e)
        {
            // TODO: estos valores deberían venir de la UI (combos, textbox…)
            var filtro = new MateriasFiltro(codCarrera: 101, codPlan: 1, anio: 2025, semestre: "I");

            var datos = await _svc.ObtenerOfertadasAsync(filtro);

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