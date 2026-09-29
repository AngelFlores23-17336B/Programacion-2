using System.ComponentModel.DataAnnotations;

namespace WebEmpresa.Models
{
    public class Cliente
    {
        public int Id_cliente { get; set; }

        [Required(ErrorMessage = "El CUI es obligatorio.")]
        public string? cui { get; set; }

        [Required(ErrorMessage = "El NIT es obligatorio.")]
        public string? nit { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string? apellidos { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string? direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string? telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? fecha_nacimiento { get; set; } = DateTime.Now;
    }
}