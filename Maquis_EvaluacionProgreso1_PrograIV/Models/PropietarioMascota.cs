using System.ComponentModel.DataAnnotations;

namespace Maquis_EvaluacionProgreso1_PrograIV.Models
{
    public class PropietarioMascota
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public static string NombreDelEstudiante = "Kevin Maquis";
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El telefono no puede tener más de 10 caracteres.")]
        public string Telefono { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Correo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public bool TieneDeuda { get; set; }
        public decimal Deuda { get; set; }
    }
}
