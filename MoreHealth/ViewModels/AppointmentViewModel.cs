using MoreHealth.Models;
using System;

namespace MoreHealth.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public string Address { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get => DateStart.AddMinutes(15); }
        
        public string GetDate { get => DateStart.ToShortTimeString(); }
    }
}
