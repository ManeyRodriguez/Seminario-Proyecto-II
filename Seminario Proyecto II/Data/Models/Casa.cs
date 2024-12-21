using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Casa
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public string Calle { get; set; }
        public string NumCasa { get; set; }
        public string Tipo { get; set; } // Apartamento o Casa
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Residente Residente { get; set; }
    }

}
