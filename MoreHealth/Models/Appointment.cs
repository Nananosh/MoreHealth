using System;

namespace MoreHealth.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Cabinet Cabinet { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public bool IsHome { get; set; }
    }
}