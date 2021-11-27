using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
        public Department Department { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}