using System;

namespace MoreHealth.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public string Address { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}