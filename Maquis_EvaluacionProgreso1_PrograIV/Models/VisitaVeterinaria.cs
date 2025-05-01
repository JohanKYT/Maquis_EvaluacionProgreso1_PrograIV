using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maquis_EvaluacionProgreso1_PrograIV.Models
{
    public class VisitaVeterinaria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de la visita es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El motivo de la visita es obligatorio.")]
        [AllowedValues("Vacunacion", "Revision General", "Cirugia", ErrorMessage = "El motivo de la visita debe ser 'Vacunacion', 'Revision General' o 'Cirugia'.")]
        [MaxLength(100, ErrorMessage = "El motivo no puede tener más de 100 caracteres.")]
        public string MotivoVisita { get; set; }
        public decimal Costo
        {
            get
            {
                if (MotivoVisita == "Vacunacion")
                    return 30;
                else if (MotivoVisita == "Revision General")
                    return 20;
                else if (MotivoVisita == "Cirugia")
                    return 100;
                else
                    return 0;
            }
        }
        [Required(ErrorMessage = "El diagnóstico es obligatorio.")]
        public bool requiereMedicacion { get; set; }
        public decimal CostoMedicacion { get; set; } = 0;
        
        public decimal CostoTotal
        {
            get
            {
                return Costo + (requiereMedicacion ? CostoMedicacion : 0);
            }
        }
        public int MascotaId { get; set; }
        [ForeignKey("MascotaId")]
        public Mascota? Mascota { get; set; }
    }
}
