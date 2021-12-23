using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoreHealth.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public List<Doctor> Doctors { get; set; }
    }
}