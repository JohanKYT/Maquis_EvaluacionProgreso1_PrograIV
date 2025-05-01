using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maquis_EvaluacionProgreso1_PrograIV.Models;

namespace Maquis_EvaluacionProgreso1_PrograIV.Models {  }
    public enum MotivoVisitaEnum
    {
        Vacunacion,
        RevisionGeneral,
        Cirugia
    }

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
    public MotivoVisitaEnum MotivoVisita { get; set; }
    public decimal Costo => MotivoVisita switch
    {
        MotivoVisitaEnum.Vacunacion => 30,
        MotivoVisitaEnum.RevisionGeneral => 20,
        MotivoVisitaEnum.Cirugia => 100,
        _ => 0
    };
    [Required(ErrorMessage = "El diagnóstico es obligatorio.")]
    public bool RequiereMedicacion { get; set; }
    public decimal CostoMedicacion { get; set; } = 0;
    public decimal CostoTotal => Costo + (RequiereMedicacion ? CostoMedicacion : 0);
    public int MascotaId { get; set; }
    [ForeignKey("MascotaId")]
    public Mascota? Mascota { get; set; }
}

