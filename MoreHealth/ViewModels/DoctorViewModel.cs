using MoreHealth.Models;

namespace ItransitionCourseProject.ViewModels.Account
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Specialization Specialization { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
    }
}