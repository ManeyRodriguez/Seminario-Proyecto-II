using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class PersonaBusqueda
    {
        public string Nombre { get; set; }
        public string DocID { get; set; }
        public string Casa { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string TipoPersona { get; set; }
        public DateTime? FechaHoraExp { get; set; }
    }

}


