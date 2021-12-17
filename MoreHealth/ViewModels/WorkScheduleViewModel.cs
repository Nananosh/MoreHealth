using MoreHealth.Models;
using System;

namespace MoreHealth.ViewModels
{
    public class WorkScheduleViewModel
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public int? DoctorId
        {
            get => Doctor?.Id;
            set
            {
                if (value == null)
                {
                    Doctor = null;
                    return;
                }

                if (Doctor == null)
                {
                    Doctor = new Doctor();
                }

                Doctor.Id = value.Value;
            }
        }
        public string RecurrenceRule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
