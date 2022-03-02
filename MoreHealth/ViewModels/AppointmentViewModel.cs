using MoreHealth.Models;
using System;

namespace MoreHealth.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public PatientViewModel Patient { get; set; }
        public int? PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public string Address { get; set; }
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public string GetDate
        {
            get => DateStart.ToShortTimeString();
        }

        public string Title
        {
            get
            {
                if (PatientId != null)
                {
                    return $"{Patient.Surname} {Patient.Name} {Patient.LastName}";
                }
                else
                {
                    return "Талон свободен";
                }
            }
        }
    }
}