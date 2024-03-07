using KYC360_Assessment.Entites;

namespace KYC360_Assessment.Dtos.CreateDto
{
    public record struct PatientCreateDto(
            bool Deceased,
            string Gender,
            List<NameCreateDto> Names,
            List<AddressCreateDto>? Addresses,
            List<DateCreateDto> Dates
        );

}
