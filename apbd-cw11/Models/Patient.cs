using System.ComponentModel.DataAnnotations;

namespace apbd_cw11.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(60)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}