using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminario_Proyecto_II.Data.Models
{
    public class CodigoDeAcceso
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        [MaxLength(50)] 
        public string Codigo { get; set; }

        [Required] 
        public TipoAcceso Tipo { get; set; }

        [ForeignKey("PersonaRelacionada")] 
        public int PersonaId { get; set; }

        [Required] 
        public DateTime FechaIn { get; set; }

        [Required] 
        public DateTime FechaFn { get; set; }

        [Required] 
        public EstadoAcceso Estado { get; set; }

        [MaxLength(100)] 
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
