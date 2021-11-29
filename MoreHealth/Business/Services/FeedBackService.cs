using MoreHealth.Business.Interfaces;
using MoreHealth.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoreHealth.Business.Services
{
    public class FeedBackService : IFeedBackService
    {

        public IEnumerable<Doctor> GetAllDoctors(ApplicationContext db)
        {
            IEnumerable<Doctor> doctors = db.Doctor;

            return doctors;
        }

        public IEnumerable<Specialization> GetAllSpecialization(ApplicationContext db)
        {
            var specialization = db.Specialization;

            return specialization;
        }

        public IEnumerable<Department> GetAllDepartment(ApplicationContext db)
        {
            var specialization = db.Department;

            return specialization;
        }
        
        public IEnumerable<Specialization> GetSpecializationsById(ApplicationContext db, int id)
        {
            var specializations = db.Specialization.Where(x => x.Department.Id == id);

            return specializations;
        }
        
        public IEnumerable<Doctor> GetDoctorsBySpecializaton(ApplicationContext db, int id)
        {
            var doctors = db.Doctor.Where(x => x.Specialization.Id == id);

            return doctors;
        }
    }
}
