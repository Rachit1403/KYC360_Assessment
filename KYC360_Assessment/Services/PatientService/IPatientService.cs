using KYC360_Assessment.Dtos.CreateDto;
using KYC360_Assessment.Dtos.UpdateDto;
using KYC360_Assessment.Entites;

namespace KYC360_Assessment.Services.PatientService
{
    public interface IPatientService
    {
        //Task<List<Patient>> GetAllPatients();
        Task<ServiceResponse<List<Patient>>> GetAllPatients(string? search, string? gender, DateTime? startDate, DateTime? endDate, List<String>? countries, int page, int pageSize, string sortBy, bool desc);
        Task<ServiceResponse<Patient>> GetPatientById(int id);
        Task<ServiceResponse<List<Patient>>> AddPatient(PatientCreateDto newPatient);
        Task<ServiceResponse<Patient>> UpdatePatient(PatientUpdateDto updatedPatient);
        Task<ServiceResponse<List<Patient>>> DeletePatient(int id);
    }
}
