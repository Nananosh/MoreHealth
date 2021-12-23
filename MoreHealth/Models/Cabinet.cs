using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoreHealth.Models
{
    public class Cabinet
    {
        public int Id { get; set; }
        public int CabinetNumber { get; set; }
        [JsonIgnore]
        public List<Doctor> Doctors { get; set; }
    }
}