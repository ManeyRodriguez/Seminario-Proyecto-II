using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Administrador>> ObtenerTodos();

        Task<Administrador> ObtenerPorId(int id);

        Task Agregar(Administrador residente);

        Task Actualizar(Administrador residente);

        Task Eliminar(int id);
    }

}
