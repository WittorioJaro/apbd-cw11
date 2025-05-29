using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_cw11.Models;

public class PrescriptionMedicament
{   
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }
    
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }

    public int? Dose { get; set; }
    
    public Prescription Prescription { get; set; }
    public Medicament Medicament { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }
}