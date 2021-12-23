using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoreHealth.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Specialization? Specialization { get; set; }
        public int? SpecializationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public List<Feedback> Feedbacks { get; set; }
        public Cabinet? Cabinet { get; set; }
        public int? CabinetId { get; set; }
        [JsonIgnore]
        public List<WorkSchedule> WorkSchedules { get; set; }
    }
}