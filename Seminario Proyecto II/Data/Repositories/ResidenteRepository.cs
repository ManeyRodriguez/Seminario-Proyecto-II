using Seminario_Proyecto_II.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class ResidenteRepository : IResidenteRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de la base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public ResidenteRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todos los residentes de la base de datos.
        /// </summary>
        /// <returns>Lista de residentes.</returns>
        public async Task<IEnumerable<Residente>> ObtenerTodos()
        {
            try
            {
                return await _context.Residentes
                    .Include(r => r.Casas) 
                    .AsNoTracking() 
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todos los residentes.", ex);
            }
        }


        /// <summary>
        /// Obtiene un residente por su ID.
        /// </summary>
        /// <param name="id">ID del residente.</param>
        /// <returns>El residente correspondiente o null si no existe.</returns>
        public async Task<Residente> ObtenerPorId(int id)
        {
            try
            {
                return await _context.Residentes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id)
                    ?? throw new KeyNotFoundException($"No se encontró el residente con ID {id}.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener el residente con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Agrega un nuevo residente a la base de datos.
        /// </summary>
        /// <param name="residente">Entidad del residente a agregar.</param>
        public async Task Agregar(Residente residente)
        {
            if (residente == null)
                throw new ArgumentNullException(nameof(residente));

            try
            {
                await _context.Residentes.AddAsync(residente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el residente.", ex);
            }
        }

        /// <summary>
        /// Actualiza los datos de un residente existente.
        /// </summary>
        /// <param name="residente">Entidad del residente a actualizar.</param>
        public async Task Actualizar(Residente residente)
        {
            if (residente == null || residente.Id < 0)
                throw new ArgumentNullException(nameof(residente));

            try
            {
                var residenteExistente = await _context.Residentes
                    .FirstOrDefaultAsync(r => r.Id == residente.Id);

                if (residenteExistente == null)
                    throw new KeyNotFoundException($"Residente con ID {residente.Id} no encontrado.");



                residenteExistente.Nombres = residente.Nombres.Trim();
                residenteExistente.Apellidos = residente.Apellidos.Trim();
                residenteExistente.Tel = residente.Tel.Trim();
                residenteExistente.Correo = residente.Correo.Trim();                
                residenteExistente.Estado = residente.Estado;

                _context.Residentes.Update(residenteExistente);     
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el residente.", ex);
            }
        }




        /// <summary>
        /// Elimina un residente por su ID.
        /// </summary>
        /// <param name="id">ID del residente a eliminar.</param>
        public async Task Eliminar(int id)
        {
            try
            {
                var residente = await _context.Residentes.FindAsync(id);
                if (residente == null)
                    throw new KeyNotFoundException($"No se encontró el residente con ID {id}.");

                _context.Residentes.Remove(residente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar el residente.", ex);
            }
        }

        public async Task<IEnumerable<Residente>> BuscarResidentes(string searchTerm)
        {          
            return await _context.Residentes
                .Where(r => r.Nombres.Contains(searchTerm) ||
                            r.Tel.Contains(searchTerm) ||
                            r.DocID.Contains(searchTerm))
                .ToListAsync();
        }
    }
}

