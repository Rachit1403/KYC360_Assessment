using System.Text.Json.Serialization;

namespace KYC360_Assessment.Entites
{
    public class Name
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }

}
