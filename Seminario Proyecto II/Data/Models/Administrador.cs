using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string PassHash { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}
