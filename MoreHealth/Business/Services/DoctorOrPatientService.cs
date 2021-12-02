using System.Linq;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

namespace MoreHealth.Business.Services
{
    public class DoctorOrPatientService : IDoctorOrPatientService
    {
        public int GetPatientByUserId(ApplicationContext db, string userId)
        {
            var patient = db.Patient.FirstOrDefault(p => p.User.Id == userId);
            
            return patient.Id;
        }

        public int GetDoctorByUserId(ApplicationContext db, string userId)
        {
            var doctor = db.Doctor.FirstOrDefault(d => d.User.Id == userId);
            
            return doctor.Id;
        }
    }
}