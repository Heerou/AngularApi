using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndApi.Models;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    public string? Usuario1 { get; set; }

    public string? Pass { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
