﻿using Seminario_Proyecto_II.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Residente
{    
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
    public string Apellidos { get; set; }

    [Required(ErrorMessage = "El documento de identificación es obligatorio.")]
    [StringLength(20, ErrorMessage = "El documento de identificación no puede exceder los 20 caracteres.")]
    public string DocID { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [StringLength(100, ErrorMessage = "El correo no puede exceder los 100 caracteres.")]
    public string Correo { get; set; }

    [StringLength(11, ErrorMessage = "El teléfono no puede exceder los 11 caracteres.")]    
    public string Tel { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(24, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 24 caracteres.")]
    public string PassHash { get; set; }
        
    public string Estado { get; set; } = "Activo";

    public DateTime Fecha { get; set; } = DateTime.Now;

    public ICollection<Casa> Casas { get; set; } = new List<Casa>();
    public ICollection<PersonaRelacionada> PersonasRelacionadas { get; set; } = new List<PersonaRelacionada>();
    public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
