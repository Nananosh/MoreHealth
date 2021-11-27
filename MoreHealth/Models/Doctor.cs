using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Specialization Specialization { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Cabinet> Cabinets { get; set; }
        public List<WorkSchedule> WorkSchedules { get; set; }
    }
}