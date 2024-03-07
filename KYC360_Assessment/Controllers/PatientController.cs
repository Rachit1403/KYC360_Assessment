using Azure;
using KYC360_Assessment.Data;
using KYC360_Assessment.Dtos.CreateDto;
using KYC360_Assessment.Dtos.UpdateDto;
using KYC360_Assessment.Entites;
using KYC360_Assessment.Services.PatientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KYC360_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

       
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> Get([FromQuery] string? search,
            [FromQuery] string? gender ,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] List<string>? countries,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Gender",
            [FromQuery] bool desc = false)
        {
            
            return Ok(await _patientService.GetAllPatients(search,gender, startDate, endDate, countries, page, pageSize, sortBy, desc));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Patient>>> GetSingle(int id)
        {
            var response = await _patientService.GetPatientById(id);
            if(response.Data is null) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> Add(PatientCreateDto request)
        {
            return Ok(await _patientService.AddPatient(request));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Patient>>> Update(PatientUpdateDto request)
        {
            var response = await _patientService.UpdatePatient(request);
            if (response.Data is null) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Patient>>> Delete(int id)
        {
            var response = await _patientService.DeletePatient(id);
            if (response.Data is null) return NotFound(response);
            return Ok(response);
        }
    }
}
