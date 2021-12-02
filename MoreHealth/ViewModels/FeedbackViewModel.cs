using System.ComponentModel.DataAnnotations;
using MoreHealth.Models;

namespace ItransitionCourseProject.ViewModels.Account
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public int ? PatientId
        {
            get => Patient?.Id;
            set
            {
                if (value == null)
                {
                    Patient = null;
                    return;
                }

                if (Patient == null)
                {
                    Patient = new Patient();
                }

                Patient.Id = value.Value;
            }
        }

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

        public string Text { get; set; }
        public bool IsLike { get; set; }
    }
}