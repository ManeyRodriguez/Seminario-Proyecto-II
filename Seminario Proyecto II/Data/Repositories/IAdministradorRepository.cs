using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public interface IAdministradorRepository
    {
        /// <summary>
        /// Obtiene todos los administradores de la base de datos.
        /// </summary>
        /// <returns>Lista de administradores.</returns>
        Task<IEnumerable<Administrador>> ObtenerTodos();

        /// <summary>
        /// Obtiene un administrador por su ID.
        /// </summary>
        /// <param name="id">ID del administrador.</param>
        /// <returns>El administrador correspondiente o null si no existe.</returns>
        Task<Administrador> ObtenerPorId(int id);

        /// <summary>
        /// Agrega un nuevo administrador a la base de datos.
        /// </summary>
        /// <param name="administrador">Entidad del administrador a agregar.</param>
        Task Agregar(Administrador administrador);

        /// <summary>
        /// Actualiza los datos de un administrador existente.
        /// </summary>
        /// <param name="administrador">Entidad del administrador a actualizar.</param>
        Task Actualizar(Administrador administrador);

        /// <summary>
        /// Elimina un administrador por su ID.
        /// </summary>
        /// <param name="id">ID del administrador a eliminar.</param>
        Task Eliminar(int id);

        /// <summary>
        /// Valida el login de un administrador con su correo y contraseña.
        /// </summary>
        /// <param name="correo">Correo del administrador.</param>
        /// <param name="password">Contraseña del administrador.</param>
        /// <returns>El administrador correspondiente si las credenciales son correctas, de lo contrario, null.</returns>
        Task<Administrador> ValidarLogin(string correo, string password);
    }
}
