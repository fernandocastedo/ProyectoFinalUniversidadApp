using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProyectoFinalUniversidadApp.DAL
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<MateriaDto>> ListarOfertadasAsync(MateriasFiltro filtro);
    }

    public class MateriaRepository : IMateriaRepository
    {
        private readonly string _cn;
        public MateriaRepository(string cadena) => _cn = cadena;

        public async Task<IEnumerable<MateriaDto>> ListarOfertadasAsync(MateriasFiltro f)
        {
            const string sql = "EXEC dbo.sp_ReporteMateriasOfertadas @CodCarrera,@CodPlanEstudio,@Anio,@Semestre";
            var lista = new List<MateriaDto>();

            await using var con = new SqlConnection(_cn);
            await using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@CodCarrera", f.CodCarrera);
            cmd.Parameters.AddWithValue("@CodPlanEstudio", f.CodPlan);
            cmd.Parameters.AddWithValue("@Anio", f.Anio);
            cmd.Parameters.AddWithValue("@Semestre", f.Semestre);

            await con.OpenAsync();
            await using var rd = await cmd.ExecuteReaderAsync();

            while (await rd.ReadAsync())
                lista.Add(new MateriaDto(rd.GetString(1), rd.GetString(2), rd.GetByte(3)));

            return lista;
        }
    }
}
