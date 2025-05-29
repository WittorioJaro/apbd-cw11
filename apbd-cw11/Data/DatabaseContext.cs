using apbd_cw11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw11.Data;

public class DatabaseContext : DbContext
{
    // ctor dla DI
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    // DbSet’y = tabele
    public DbSet<Patient> Patients                     => Set<Patient>();
    public DbSet<Doctor> Doctors                       => Set<Doctor>();
    public DbSet<Medicament> Medicaments               => Set<Medicament>();
    public DbSet<Prescription> Prescriptions           => Set<Prescription>();
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments => Set<PrescriptionMedicament>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

        mb.Entity<Prescription>()
            .ToTable(t => t.HasCheckConstraint("CK_Prescription_Dates", "[DueDate] >= [Date]"));
        
        mb.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Jan",  LastName = "Kowalski", BirthDate = new DateTime(1985, 4, 12) },
            new Patient { IdPatient = 2, FirstName = "Anna", LastName = "Nowak",    BirthDate = new DateTime(1990,11,  5) }
        );

        mb.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Adam", LastName = "Nowicki", Email = "a.nowicki@clinic.pl" }
        );

        mb.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Aspirin",     Description = "Painkiller",  Type = "Tablet"  },
            new Medicament { IdMedicament = 2, Name = "Amoxicillin", Description = "Antibiotic",  Type = "Capsule" },
            new Medicament { IdMedicament = 3, Name = "Loratadine",  Description = "Antihist.",   Type = "Tablet"  }
        );

        mb.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = new DateTime(2025,5,29), DueDate = new DateTime(2025,6, 5), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2025,5,29), DueDate = new DateTime(2025,6,12), IdPatient = 2, IdDoctor = 1 }
        );

        mb.Entity<PrescriptionMedicament>().HasData(
            new { IdPrescription = 1, IdMedicament = 1, Dose = 500, Details = "1 tab co 8h" },
            new { IdPrescription = 1, IdMedicament = 2, Dose = 250, Details = "1 kaps co 12h" },
            new { IdPrescription = 2, IdMedicament = 3, Dose = (int?)null, Details = "1 tab dziennie" }
        );
        
    }
}