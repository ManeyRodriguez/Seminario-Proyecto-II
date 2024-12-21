using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public int AccesoId { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } // N=No leída, L=Leída

        public Residente Residente { get; set; }
        public HistorialDeAcceso HistorialDeAcceso { get; set; }
    }
}
