using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidadApp.Shared
{
    public record MateriaDto(string Sigla, string Nombre, byte Creditos);

    public record MateriasFiltro(
        int CodCarrera,
        int CodPlan,
        int Anio,
        string Semestre);
    internal class MateriaDtos
    {
    }
}
