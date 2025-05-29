namespace apbd_cw11.DTOs;

public class AddPrescriptionDTO
{
    public PatientDTO Patient { get; set; }
    public int IdDoctor { get; set; }
    public List<MedicamentDTO> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class PatientDTO
{
    public int IdPatient { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public String Description { get; set; }
}

