using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maquis_EvaluacionProgreso1_PrograIV.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Raza { get; set; }
        [Required]
        public decimal Peso { get; set; } 
        public DateTime FechaNacimiento { get; set; }
        public int PropietarioMascotaId { get; set; }
        [ForeignKey("PropietarioMascotaId")]
        public PropietarioMascota? PropietarioMascota { get; set; }
    }
}
