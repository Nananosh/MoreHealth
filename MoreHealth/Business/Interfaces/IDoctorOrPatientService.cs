using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IDoctorOrPatientService
    {
        public int GetPatientByUserId(ApplicationContext db, string userId);
        public int GetDoctorByUserId(ApplicationContext db, string userId);
    }
}