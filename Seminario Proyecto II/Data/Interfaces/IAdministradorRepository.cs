using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Interfaces
{
    public interface IAdministradorRepository
    {
        
        Task<IEnumerable<Administrador>> ObtenerTodos();       
        Task<Administrador> ObtenerPorId(int id);        
        Task Agregar(Administrador administrador);       
        Task Actualizar(Administrador administrador);
        Task Eliminar(int id);
        Task<Administrador> ValidarLogin(string correo, string password);
    }
}
