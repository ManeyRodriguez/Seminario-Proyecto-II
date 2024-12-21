using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class HistorialDeAcceso
    {
        public int Id { get; set; }
        public int CodigoId { get; set; }
        public DateTime Fecha { get; set; }
        public ResultadoAcceso Resultado { get; set; } // Autorizado o Denegado
        public TipoAccesoPuerta TipoAcceso { get; set; } // Entrada o Salida
        public string Comentarios { get; set; }

        public CodigoDeAcceso CodigoDeAcceso { get; set; }
    }

    public enum ResultadoAcceso
    {
        Autorizado = 1,
        Denegado = 2
    }

    public enum TipoAccesoPuerta
    {
        Entrada = 1,
        Salida = 2
    }

}
