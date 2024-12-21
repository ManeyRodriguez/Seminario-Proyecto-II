using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Residente
    {            
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocID { get; set; }
        public string Correo { get; set; }
        public string Tel { get; set; }
        public string PassHash { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } // Activo o Inactivo

        public ICollection<Casa> Casas { get; set; }
        public ICollection<PersonaRelacionada> PersonasRelacionadas { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }
    }

}
