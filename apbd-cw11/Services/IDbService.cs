using apbd_cw11.DTOs;

namespace apbd_cw11.Services;

public interface IDbService
{
    public Task<int> AddPrescriptionAsync(AddPrescriptionDTO prescription);
    public Task<PatientDetailsDto> GetPatientAsync(int idPatient);
}