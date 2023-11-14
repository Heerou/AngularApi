using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndApi.Models;

public partial class Persona
{
    [Key]
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public int? NoIdentificacion { get; set; }

    public string? Email { get; set; }

    public string? TpIdentificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string IdentificacionCompleta { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;
}
