using KYC360_Assessment.Dtos.CreateDto;
using KYC360_Assessment.Dtos.UpdateDto;
using KYC360_Assessment.Entites;

namespace KYC360_Assessment.Services.PatientService
{
    public interface IPatientService
    {
        //Task<List<Patient>> GetAllPatients();
        Task<List<Patient>> GetAllPatients(string? search, string? gender, DateTime? startDate, DateTime? endDate, List<String>? countries, int page, int pageSize, string sortBy, bool desc);
        Task<Patient> GetPatientById(int id);
        Task<List<Patient>> AddPatient(PatientCreateDto newPatient);
        Task<Patient> UpdatePatient(PatientUpdateDto updatedPatient);
        Task<List<Patient>> DeletePatient(int id);
    }
}
