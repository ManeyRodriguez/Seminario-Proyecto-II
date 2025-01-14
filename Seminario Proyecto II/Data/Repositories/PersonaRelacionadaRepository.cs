using Microsoft.EntityFrameworkCore;
using Seminario_Proyecto_II.Data.Interfaces;
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


        public PersonaRelacionadaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    
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
