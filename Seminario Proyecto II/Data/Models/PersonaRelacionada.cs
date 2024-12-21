using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class PersonaRelacionada
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocID { get; set; }
        public TipoPersona Tipo { get; set; } 
        public string Proposito { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Residente Residente { get; set; }
        public ICollection<CodigoDeAcceso> CodigosDeAcceso { get; set; }
    }

    public enum TipoPersona
    {
        Familiar = 1,
        Invitado = 2,
        Trabajador = 3
    }

}
