using Seminario_Proyecto_II.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class CasaRepository : ICasaRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de la base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public CasaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todas las casas de la base de datos.
        /// </summary>
        /// <returns>Lista de casas.</returns>
        public async Task<IEnumerable<Casa>> ObtenerTodos()
        {
            try
            {
                return await _context.Casas
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todas las casas.", ex);
            }
        }

        /// <summary>
        /// Obtiene una casa por su ID.
        /// </summary>
        /// <param name="id">ID de la casa.</param>
        /// <returns>La casa correspondiente o null si no existe.</returns>
        public async Task<Casa> ObtenerPorId(int id)
        {
            try
            {
                return await _context.Casas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new KeyNotFoundException($"No se encontró la casa con ID {id}.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener la casa con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Agrega una nueva casa a la base de datos.
        /// </summary>
        /// <param name="casa">Entidad de la casa a agregar.</param>
        public async Task Agregar(Casa casa)
        {
            if (casa == null)
                throw new ArgumentNullException(nameof(casa));

            try
            {
                await _context.Casas.AddAsync(casa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar la casa.", ex);
            }
        }

        /// <summary>
        /// Actualiza los datos de una casa existente.
        /// </summary>
        /// <param name="casa">Entidad de la casa a actualizar.</param>
        public async Task Actualizar(Casa casa)
        {
            if (casa == null || casa.Id < 0)
                throw new ArgumentNullException(nameof(casa));

            try
            {
                var casaExistente = await _context.Casas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == casa.Id);

                if (casaExistente == null)
                    throw new KeyNotFoundException($"Casa con ID {casa.Id} no encontrada.");

                _context.Casas.Update(casa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar la casa.", ex);
            }
        }

        /// <summary>
        /// Elimina una casa por su ID.
        /// </summary>
        /// <param name="id">ID de la casa a eliminar.</param>
        public async Task Eliminar(int id)
        {
            try
            {
                var casa = await _context.Casas.FindAsync(id);
                if (casa == null)
                    throw new KeyNotFoundException($"No se encontró la casa con ID {id}.");

                _context.Casas.Remove(casa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar la casa.", ex);
            }
        }
    }
}
