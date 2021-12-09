using System;

namespace MoreHealth.Models
{
    public class AppointmentHome
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}