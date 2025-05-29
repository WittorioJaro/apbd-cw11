using System.ComponentModel.DataAnnotations;

namespace apbd_cw11.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(60)]
    public string LastName { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; }
}