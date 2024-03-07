using System.Text.Json.Serialization;

namespace KYC360_Assessment.Entites
{
    public class Address
    {
        public int Id { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
