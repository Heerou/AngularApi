namespace BackEndApi.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public int? NoIdentificacion { get; set; }

        public string? Email { get; set; }

        public string? TpIdentificacion { get; set; }

        public string? FechaCreacion { get; set; }

        public string IdentificacionCompleta { get; set; } = null!;

        public string NombreCompleto { get; set; } = null!;
    }
}
