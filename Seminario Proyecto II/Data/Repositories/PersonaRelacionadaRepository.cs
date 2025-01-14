using Microsoft.EntityFrameworkCore;
using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class PersonaRelacionadaRepository : IPersonaRelacionadaRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de la base de datos.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public PersonaRelacionadaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todas las personas relacionadas de la base de datos.
        /// </summary>
        /// <returns>Lista de personas relacionadas.</returns>
        public async Task<IEnumerable<PersonaRelacionada>> ObtenerTodos()
        {
            try
            {
                return await _context.PersonasRelacionadas                   
                    .Include(r => r.Casa)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todas las personas relacionadas.", ex);
            }
        }

        /// <summary>
        /// Obtiene una persona relacionada por su ID.
        /// </summary>
        /// <param name="id">ID de la persona relacionada.</param>
        /// <returns>La persona relacionada correspondiente o null si no existe.</returns>
        public async Task<PersonaRelacionada> ObtenerPorId(int id)
        {
            try
            {
                return await _context.PersonasRelacionadas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id)
                    ?? throw new KeyNotFoundException($"No se encontró la persona relacionada con ID {id}.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener la persona relacionada con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Agrega una nueva persona relacionada a la base de datos.
        /// </summary>
        /// <param name="personaRelacionada">Entidad de la persona relacionada a agregar.</param>
        public async Task Agregar(PersonaRelacionada personaRelacionada)
        {
            if (personaRelacionada == null)
                throw new ArgumentNullException(nameof(personaRelacionada));

            try
            {
                await _context.PersonasRelacionadas.AddAsync(personaRelacionada);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar la persona relacionada.", ex);
            }
        }

        /// <summary>
        /// Actualiza los datos de una persona relacionada existente.
        /// </summary>
        /// <param name="personaRelacionada">Entidad de la persona relacionada a actualizar.</param>
        public async Task Actualizar(PersonaRelacionada personaRelacionada)
        {
            if (personaRelacionada == null || personaRelacionada.Id <= 0)
                throw new ArgumentNullException(nameof(personaRelacionada), "La persona relacionada no puede ser nula o tener un ID inválido.");

            try
            {
                var personaExistente = await _context.PersonasRelacionadas
                    .FirstOrDefaultAsync(p => p.Id == personaRelacionada.Id);

                if (personaExistente == null)
                    throw new KeyNotFoundException($"Persona relacionada con ID {personaRelacionada.Id} no encontrada.");

                if (string.IsNullOrEmpty(personaRelacionada.Nombres) || string.IsNullOrEmpty(personaRelacionada.Apellidos))
                    throw new ArgumentException("Los campos de nombres y apellidos no pueden estar vacíos.");

                personaExistente.Nombres = personaRelacionada.Nombres.Trim();
                personaExistente.Apellidos = personaRelacionada.Apellidos.Trim();
                personaExistente.DocID = personaRelacionada.DocID.Trim();
                personaExistente.Tipo = personaRelacionada.Tipo;
                personaExistente.FechayHoraExp = personaRelacionada.FechayHoraExp;    
                personaExistente.Estado = personaRelacionada.Estado;
                personaExistente.CasaId = personaRelacionada.CasaId;

                _context.PersonasRelacionadas.Update(personaExistente);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException("Error en los parámetros proporcionados.", ex);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Error en los datos proporcionados para la actualización.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar la persona relacionada.", ex);
            }
        }

        /// <summary>
        /// Elimina una persona relacionada por su ID.
        /// </summary>
        /// <param name="id">ID de la persona relacionada a eliminar.</param>
        public async Task Eliminar(int id)
        {
            try
            {
                var personaRelacionada = await _context.PersonasRelacionadas.FindAsync(id);
                if (personaRelacionada == null)
                    throw new KeyNotFoundException($"No se encontró la persona relacionada con ID {id}.");

                _context.PersonasRelacionadas.Remove(personaRelacionada);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar la persona relacionada.", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las personas relacionadas a una casa.
        /// </summary>
        /// <param name="CasaId">ID de la casa.</param>
        /// <returns>Lista de personas relacionadas a la casa.</returns>
        public async Task<IEnumerable<PersonaRelacionada>> ObtenerPorCasaId(int casaId)
        {
            try
            {
                return await _context.PersonasRelacionadas
                    .Where(p => p.CasaId == casaId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener las personas relacionadas para el residente con ID {casaId}.", ex);
            }
        }
    }
}
