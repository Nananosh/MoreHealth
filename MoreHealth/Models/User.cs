using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MoreHealth.Models
{
    public class User : IdentityUser
    {
        public string UserImage { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
    }
}