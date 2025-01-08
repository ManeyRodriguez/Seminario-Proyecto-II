using Seminario_Proyecto_II.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public interface ICasaRepository
    {
       
        Task<IEnumerable<Casa>> ObtenerTodos();

        Task<IEnumerable<Casa>> BuscarCasas(string busqueda);

        Task<Casa> ObtenerPorId(int id);

        Task Agregar(Casa residente);

        Task Actualizar(Casa residente);

        Task Eliminar(int id);
    }
}
