using KYC360_Assessment.Data;
using KYC360_Assessment.Dtos.CreateDto;
using KYC360_Assessment.Dtos.UpdateDto;
using KYC360_Assessment.Entites;
using Microsoft.EntityFrameworkCore;

namespace KYC360_Assessment.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly DataContext _context;

        public PatientService(DataContext context)
        {
            _context = context;
        }

        /*public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _context.Patients
                .Include(c => c.Names)
                .Include(c => c.Addresses)
                .Include(c => c.Dates)
                .ToListAsync();

            return patients;
        } 
        */

        /*public async Task<List<Patient>> GetAllPatients(string search)
        {
            var patients = await _context.Patients
                .Include(patient => patient.Addresses)
                .Include(patient => patient.Names)
                .Include(patient => patient.Dates)
                .Where(patient =>
                patient.Addresses.Any(address => address.Country.Contains(search)) ||
                patient.Addresses.Any(address => address.AddressLine.Contains(search)) ||
                patient.Names.Any(name => name.FirstName.Contains(search)) ||
                patient.Names.Any(name => name.MiddleName.Contains(search)) ||
                patient.Names.Any(name => name.Surname.Contains(search)))
            .ToListAsync();

            return patients;
        } */

        public async Task<List<Patient>> GetAllPatients(string? search, string? gender, DateTime? startDate, DateTime? endDate, List<String>? countries,
                                                        int page, int pageSize, string sortBy, bool desc)
        {
            // If no search parameter is provided, return all patients
            var query = _context.Patients
                .Include(patient => patient.Addresses)
                .Include(patient => patient.Names)
                .Include(patient => patient.Dates)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(patient =>
                    patient.Addresses.Any(address => address.Country.Contains(search)) ||
                    patient.Addresses.Any(address => address.AddressLine.Contains(search)) ||
                    patient.Names.Any(name => name.FirstName.Contains(search)) ||
                    patient.Names.Any(name => name.MiddleName.Contains(search)) ||
                    patient.Names.Any(name => name.Surname.Contains(search)));
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(patient => patient.Gender == gender);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(patient =>
                    patient.Dates.Any(date =>
                        date.DateValue >= startDate && date.DateValue <= endDate));
            }

            if (countries != null && countries.Any())
            {
                query = query.Where(patient =>
                    patient.Addresses.Any(address =>
                        countries.Contains(address.Country)));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                query = desc ? query.OrderByDescending(patient => EF.Property<object>(patient, sortBy))
                             : query.OrderBy(patient => EF.Property<object>(patient, sortBy));
            }

            // Paginate the results
            var paginatedPatients = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return paginatedPatients;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _context.Patients
                .Include(c => c.Names)
                .Include(c => c.Addresses)
                .Include(c => c.Dates)
                .FirstOrDefaultAsync(c => c.Id == id);

            return patient;
        }

        public async Task<List<Patient>> AddPatient(PatientCreateDto request)
        {
            var newPatient = new Patient
            {
                Deceased = request.Deceased,
                Gender = request.Gender
            };

            var names = request.Names.Select(n => new Name { FirstName = n.FirstName, MiddleName = n.MiddleName, Surname = n.Surname, Patient = newPatient}).ToList();
            var addresses = request.Addresses.Select(a => new Address { AddressLine = a.AddressLine, City = a.City, Country = a.Country, Patient = newPatient }).ToList();
            var dates = request.Dates.Select(d => new Date { DateType = d.DateType, DateValue = d.DateValue, Patient = newPatient }).ToList();

            newPatient.Names = names;
            newPatient.Addresses = addresses;
            newPatient.Dates = dates;

            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();

            return await _context.Patients
                .Include(c => c.Names)
                .Include(c => c.Addresses)
                .Include(c => c.Dates)
                .ToListAsync();

        }

        public async Task<Patient> UpdatePatient(PatientUpdateDto request)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(c => c.Id == request.Id);
            patient.Deceased = request.Deceased;
            patient.Gender = request.Gender;

            await _context.SaveChangesAsync();

            return patient;

        }

        public async Task<List<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(c => c.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return await _context.Patients
                .Include(c => c.Names)
                .Include(c => c.Addresses)
                .Include(c => c.Dates)
                .ToListAsync();

        }

    }
}
