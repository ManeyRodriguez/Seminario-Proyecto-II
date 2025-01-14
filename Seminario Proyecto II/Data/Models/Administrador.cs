using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminario_Proyecto_II.Data.Models
{
    public class Administrador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo no puede exceder los 100 caracteres.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio.")]
        [StringLength(11, ErrorMessage = "El teléfono no puede exceder los 11 caracteres.")]           
        public string Tel { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 24 caracteres.")]
        public string PassHash { get; set; } = "12345678"; 

        [Required(ErrorMessage = "El documento de identificación es obligatorio.")]
        [StringLength(20, ErrorMessage = "El documento de identificación no puede exceder los 20 caracteres.")]
        public string DocID { get; set; }

        [NotMapped]
        public string NombreCompleto => $"{Nombres} {Apellidos}";

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
