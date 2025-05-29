using apbd_cw11.Data;
using apbd_cw11.DTOs;
using apbd_cw11.Exceptions;
using apbd_cw11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<int> AddPrescriptionAsync(AddPrescriptionDTO dto)
    {
        if (dto.Medicaments.Count > 10)
            throw new InvalidPrescriptionException("Recepta może zawierać maksymalnie 10 leków.");

        if (dto.DueDate < dto.Date)
            throw new InvalidPrescriptionException("Pole DueDate musi być późniejsze lub równe Date.");

        var patient = await _context.Patients.FindAsync(dto.Patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient 
            {
                FirstName = dto.Patient.FirstName,
                LastName  = dto.Patient.LastName,
                BirthDate = dto.Patient.BirthDate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var doctor = await _context.Doctors.FindAsync(dto.IdDoctor);
        if (doctor == null)
            throw new NotFoundException($"Lekarz o Id={dto.IdDoctor} nie istnieje.");

        var prescription = new Prescription {
            Patient  = patient,
            Doctor   = doctor,
            Date     = dto.Date,
            DueDate  = dto.DueDate,
            PrescriptionMedicaments = dto.Medicaments
                .Select(m => new PrescriptionMedicament {
                    IdMedicament = m.IdMedicament,
                    Dose         = m.Dose,
                    Details      = m.Description
                })
                .ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return prescription.IdPrescription;

    }
    public async Task<PatientDetailsDto> GetPatientAsync(int idPatient)
    {
        var dto = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientDetailsDto {
                IdPatient  = p.IdPatient,
                FirstName  = p.FirstName,
                LastName   = p.LastName,
                BirthDate  = p.BirthDate,
                Prescriptions = p.Prescriptions
                    .OrderBy(r => r.DueDate)
                    .Select(r => new PrescriptionDto {
                        IdPrescription = r.IdPrescription,
                        Date            = r.Date,
                        DueDate         = r.DueDate,
                        Medicaments     = r.PrescriptionMedicaments
                            .Select(pm => new MedicamentDto {
                                IdMedicament = pm.IdMedicament,
                                Name         = pm.Medicament.Name,
                                Dose         = pm.Dose,
                                Description  = pm.Details
                            })
                            .ToList(),
                        Doctor = new DoctorDto {
                            IdDoctor  = r.Doctor.IdDoctor,
                            FirstName = r.Doctor.FirstName,
                            LastName  = r.Doctor.LastName,
                            Email     = r.Doctor.Email
                        }
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (dto == null)
            throw new NotFoundException($"Pacjent o Id={idPatient} nie istnieje.");

        return dto;
    }

}