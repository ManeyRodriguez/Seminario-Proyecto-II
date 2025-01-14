using Seminario_Proyecto_II.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seminario_Proyecto_II.Data.Interfaces;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class CasaRepository : ICasaRepository
    {
        private readonly AppDbContext _context;


        public CasaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Casa>> ObtenerTodos()
        {
            try
            {
                return await _context.Casas
                    .AsNoTracking()
                    .Include(c => c.Residente)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todas las casas.", ex);
            }
        }


        public async Task<Casa> ObtenerPorId(int id)
        {
            try
            {
                var casa = await _context.Casas
                    .Include(c => c.Residente) 
                    .AsNoTracking()  
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (casa == null)
                {
                    throw new KeyNotFoundException($"No se encontró la casa con ID {id}.");
                }

                return casa;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener la casa con ID {id}.", ex);
            }
        }



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


        public async Task Actualizar(Casa casa)
        {
            if (casa == null || casa.Id < 0)
                throw new ArgumentNullException(nameof(casa));

            try
            {
                
                var casaExistente = await _context.Casas
                    .Include(c => c.Residente) 
                    .FirstOrDefaultAsync(c => c.Id == casa.Id);



                if (casaExistente == null)
                    throw new KeyNotFoundException($"Casa con ID {casa.Id} no encontrada.");
             
                casaExistente.Calle = casa.Calle.Trim();
                casaExistente.NumCasa = casa.NumCasa.Trim();
                casaExistente.Tipo = casa.Tipo.Trim();
                casaExistente.Fecha = casa.Fecha;

                
                if (casa.ResidenteId.HasValue && casaExistente.ResidenteId != casa.ResidenteId)
                {
                    casaExistente.ResidenteId = casa.ResidenteId;
                    casaExistente.Residente = casa.Residente; 
                }
               
                _context.Casas.Update(casaExistente);
               
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar la casa.", ex);
            }
        }



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

        public async Task<IEnumerable<Casa>> BuscarCasas(string busqueda)
        {
            try
            {
                
                var casas = await _context.Casas
                    .Include(c => c.Residente) 
                    .AsNoTracking()  
                    .Where(c =>   
                                c.Calle.Contains(busqueda) ||  
                                c.NumCasa.Contains(busqueda)) 
                    .ToListAsync();  

                if (casas == null || !casas.Any()) 
                {
                    throw new KeyNotFoundException("No se encontraron casas que coincidan con la búsqueda.");
                }

                return casas;  
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al buscar casas.", ex);
            }
        }

    }
}
