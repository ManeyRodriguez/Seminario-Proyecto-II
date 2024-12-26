using Seminario_Proyecto_II.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public interface IResidenteRepository
    {
       
        Task<IEnumerable<Residente>> ObtenerTodos();

        Task<Residente> ObtenerPorId(int id);

        Task Agregar(Residente residente);

        Task Actualizar(Residente residente);

        Task Eliminar(int id);
    }
}
