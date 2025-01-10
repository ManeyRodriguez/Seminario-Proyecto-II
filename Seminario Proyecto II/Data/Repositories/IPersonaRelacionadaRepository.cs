using Seminario_Proyecto_II.Data.Models;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public interface IPersonaRelacionadaRepository
    {
        Task Agregar(PersonaRelacionada personaRelacionada);
        Task<PersonaRelacionada> ObtenerPorId(int id);
        Task<IEnumerable<PersonaRelacionada>> ObtenerPorCasaId(int casaId);
        Task Actualizar(PersonaRelacionada personaRelacionada);
        Task Eliminar(int id);
        Task<IEnumerable<PersonaRelacionada>> ObtenerTodos();
    }
}
