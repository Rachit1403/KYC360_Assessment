using System.Text.Json.Serialization;

namespace KYC360_Assessment.Entites
{
    public class Date
    {
        public int Id { get; set; }
        public string? DateType { get; set; }
        public DateTime? DateValue { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
