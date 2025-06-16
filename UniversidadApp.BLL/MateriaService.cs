using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.BLL
{
    public interface IMateriaService
    {
        Task<IReadOnlyCollection<MateriaDto>> ObtenerOfertadasAsync(MateriasFiltro filtro);
    }

    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _repo;
        public MateriaService(IMateriaRepository repo) => _repo = repo;

        public async Task<IReadOnlyCollection<MateriaDto>> ObtenerOfertadasAsync(MateriasFiltro f)
            => (await _repo.ListarOfertadasAsync(f)).ToList().AsReadOnly();
    }
}
