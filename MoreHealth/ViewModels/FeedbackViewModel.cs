using MoreHealth.Models;
using MoreHealth.ViewModels.Account;

namespace MoreHealth.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public DoctorViewModel Doctor { get; set; }
        public int DoctorId { get; set; }
        public string Text { get; set; }
        public bool IsLike { get; set; }
    }
}