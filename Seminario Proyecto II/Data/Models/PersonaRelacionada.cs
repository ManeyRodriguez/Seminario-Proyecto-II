using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Asegúrate de incluir este namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Data.Models
{
    public class PersonaRelacionada
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "debe seleccionar un residente")]
        public int CasaId { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellidos es obligatorio.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo DocID es obligatorio.")]
        public string DocID { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "El campo Tipo es obligatorio.")]
        public TipoPersona Tipo { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; } = true;


        [Required(ErrorMessage = "La el pin debe ser obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El PIN debe tener exactamente 6 caracteres.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "El PIN debe contener solo números.")]
        public string Pin { get; set; } = string.Empty;

        public DateTime FechayHoraExp { get; set; } = DateTime.Now;

        public Casa Casa { get; set; }
        public Residente Residente { get; set; }


        [NotMapped]
        public string NombreCompleto => $"{Nombres} {Apellidos}";

        public override string ToString()
        {
            return NombreCompleto;
        }

    }

    public enum TipoPersona
    {
        Familiar = 1,
        Invitado = 2,
        Trabajador = 3
    }



}
