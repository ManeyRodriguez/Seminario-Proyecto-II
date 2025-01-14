using Seminario_Proyecto_II.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seminario_Proyecto_II.Data.Interfaces;

namespace Seminario_Proyecto_II.Data.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly AppDbContext _context;


        public AdministradorRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

 
        public async Task<IEnumerable<Administrador>> ObtenerTodos()
        {
            try
            {
                return await _context.Administradores
                    .AsNoTracking()  
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener todos los administradores.", ex);
            }
        }


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

               
                administradorExistente.Nombres = administrador.Nombres.Trim();
                administradorExistente.Apellidos = administrador.Apellidos.Trim();
                administradorExistente.Correo = administrador.Correo.Trim();
                administradorExistente.Tel = administrador.Tel.Trim();
                administradorExistente.PassHash = administrador.PassHash.Trim(); 

                _context.Administradores.Update(administradorExistente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el administrador.", ex);
            }
        }


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

      
        public async Task<Administrador> ValidarLogin(string correo, string password)
        {
            try
            {
                
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
