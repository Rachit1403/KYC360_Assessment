using KYC360_Assessment.Dtos.CreateDto;
using KYC360_Assessment.Entites;

namespace KYC360_Assessment.Dtos.UpdateDto
{
    public record struct PatientUpdateDto(
            int Id,
            bool Deceased,
            string Gender
        );

}
