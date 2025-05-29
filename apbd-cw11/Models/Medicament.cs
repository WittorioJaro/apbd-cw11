using System.ComponentModel.DataAnnotations;

namespace apbd_cw11.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? Type { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}