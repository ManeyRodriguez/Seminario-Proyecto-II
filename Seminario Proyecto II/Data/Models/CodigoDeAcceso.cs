using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class CodigoDeAcceso
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public TipoAcceso Tipo { get; set; } // Temporal o Recurrente
        public int PersonaId { get; set; }
        public DateTime FechaIn { get; set; }
        public DateTime FechaFn { get; set; }
        public string Estado { get; set; } // Activo, Usado, Expirado
        public string Restricciones { get; set; }

        public PersonaRelacionada PersonaRelacionada { get; set; }
        public ICollection<HistorialDeAcceso> HistorialDeAccesos { get; set; }
    }

    public enum EstadoAcceso
    {
        Activo = 1,
        Usado = 2,
        Expirado = 3
    }

    public enum TipoAcceso
    {
        Temporal = 1,
        Recurrente = 2
    }


}
