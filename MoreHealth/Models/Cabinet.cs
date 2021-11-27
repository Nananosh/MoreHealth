using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class Cabinet
    {
        public int Id { get; set; }
        public int CabinetNumber { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}