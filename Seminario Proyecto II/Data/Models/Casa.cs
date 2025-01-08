using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Casa
    {
        public int Id { get; set; }
     
        public int? ResidenteId { get; set; } = null;

        [Required(ErrorMessage = "La calle es obligatoria.")]
        [StringLength(100, ErrorMessage = "La calle no puede exceder los 100 caracteres.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El número de la casa es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número de casa no puede exceder los 50 caracteres.")]
        public string NumCasa { get; set; }

        [Required(ErrorMessage = "El tipo de la casa es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de casa no puede exceder los 50 caracteres.")]
        public string Tipo { get; set; }

        
        public DateTime Fecha { get; set; } = DateTime.Now;

        
        public Residente? Residente { get; set; }

        [NotMapped]
        
        public string Asignada => Residente != null ? Residente.NombreCompleto : "No asignada";
    }
}
