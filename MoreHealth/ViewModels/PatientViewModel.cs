using MoreHealth.Models;
using System;

namespace MoreHealth.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public bool IsPatient { get; set; }
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }

        public string FullName { get => Name + " " + Surname + " " + LastName; }
    }
}
