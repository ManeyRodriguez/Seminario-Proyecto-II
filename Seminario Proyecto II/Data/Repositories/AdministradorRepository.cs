using Seminario_Proyecto_II.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de la base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public AdministradorRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todos los administradores de la base de datos.
        /// </summary>
        /// <returns>Lista de administradores.</returns>
        public async Task<IEnumerable<Administrador>> ObtenerTodos()
        {
            try
            {
                return await _context.Administradores
                    .AsNoTracking()  // No es necesario hacer un seguimiento de los cambios
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todos los administradores.", ex);
            }
        }

        /// <summary>
        /// Obtiene un administrador por su ID.
        /// </summary>
        /// <param name="id">ID del administrador.</param>
        /// <returns>El administrador correspondiente o null si no existe.</returns>
        public async Task<Administrador> ObtenerPorId(int id)
        {
            try
            {
                return await _context.Administradores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id)
                    ?? throw new KeyNotFoundException($"No se encontró el administrador con ID {id}.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener el administrador con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Agrega un nuevo administrador a la base de datos.
        /// </summary>
        /// <param name="administrador">Entidad del administrador a agregar.</param>
        public async Task Agregar(Administrador administrador)
        {
            if (administrador == null)
                throw new ArgumentNullException(nameof(administrador));

            try
            {
                await _context.Administradores.AddAsync(administrador);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el administrador.", ex);
            }
        }

        /// <summary>
        /// Actualiza los datos de un administrador existente.
        /// </summary>
        /// <param name="administrador">Entidad del administrador a actualizar.</param>
        public async Task Actualizar(Administrador administrador)
        {
            if (administrador == null || administrador.Id < 0)
                throw new ArgumentNullException(nameof(administrador));

            try
            {
                var administradorExistente = await _context.Administradores
                    .FirstOrDefaultAsync(a => a.Id == administrador.Id);

                if (administradorExistente == null)
                    throw new KeyNotFoundException($"Administrador con ID {administrador.Id} no encontrado.");

                // Actualizamos las propiedades del administrador existente
                administradorExistente.Nombres = administrador.Nombres.Trim();
                administradorExistente.Apellidos = administrador.Apellidos.Trim();
                administradorExistente.Correo = administrador.Correo.Trim();
                administradorExistente.Tel = administrador.Tel.Trim();
                administradorExistente.PassHash = administrador.PassHash.Trim(); // Contraseña si se cambia

                _context.Administradores.Update(administradorExistente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el administrador.", ex);
            }
        }

        /// <summary>
        /// Elimina un administrador por su ID.
        /// </summary>
        /// <param name="id">ID del administrador a eliminar.</param>
        public async Task Eliminar(int id)
        {
            try
            {
                var administrador = await _context.Administradores.FindAsync(id);
                if (administrador == null)
                    throw new KeyNotFoundException($"No se encontró el administrador con ID {id}.");

                _context.Administradores.Remove(administrador);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar el administrador.", ex);
            }
        }

        /// <summary>
        /// Valida las credenciales de un administrador.
        /// </summary>
        /// <param name="correo">Correo del administrador.</param>
        /// <param name="password">Contraseña del administrador.</param>
        /// <returns>El administrador correspondiente si las credenciales son correctas, de lo contrario, null.</returns>
        public async Task<Administrador> ValidarLogin(string correo, string password)
        {
            try
            {
                // Usamos ToLower() para hacer la comparación insensible a mayúsculas/minúsculas
                var administrador = await _context.Administradores
                    .FirstOrDefaultAsync(a => a.Correo.ToLower() == correo.ToLower());

                if (administrador != null && administrador.PassHash == password)
                {
                    return administrador;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al validar el login del administrador.", ex);
            }
        }

    }
}
