using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace KYC360_Assessment.Entites
{
    public class Patient
    {
        public int Id { get; set; }
        public bool Deceased { get; set; }
        public string? Gender { get; set; }
        public List<Name> Names { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Date> Dates { get; set; }

        

    }
    

    

    
}
