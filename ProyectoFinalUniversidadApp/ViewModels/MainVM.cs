using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidadApp.ViewModels
{
    public class MainVM : ObservableObject
    {
        public ViewModelBase? VistaActual
        {
            get => _vistaActual;
            set => Set(ref _vistaActual, value);
        }
        private ViewModelBase? _vistaActual;

        public RelayCommand<string> CambiarVistaCmd { get; }

        private readonly IServiceProvider _sp;
        public MainVM(IServiceProvider sp)
        {
            _sp = sp;
            CambiarVistaCmd = new RelayCommand<string>(CambiarVista);
        }

        private void CambiarVista(string token)
        {
            VistaActual = token switch
            {
                "Materias" => _sp.GetRequiredService<MateriasOfertadasVM>(),
                "Asistencia" => _sp.GetRequiredService<AsistenciaMateriaVM>(),
                "Notas" => _sp.GetRequiredService<NotasEstudianteVM>(),
                "Boletin" => _sp.GetRequiredService<BoletinVM>(),
                "RegEst" => _sp.GetRequiredService<RegistrarEstudianteVM>(),
                "RegMat" => _sp.GetRequiredService<RegistrarMateriaVM>(),
                _ => null
            };
        }
    }
}
