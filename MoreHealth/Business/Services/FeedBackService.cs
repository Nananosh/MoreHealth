using System.Collections.Generic;
using System.Linq;
using MoreHealth.Business.Interfaces;
using MoreHealth.Constants.UserMessagesConstants;
using MoreHealth.Models;
using MoreHealth.ViewModels.Account;

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

        public IQueryable GetDoctorsBySpecialization(ApplicationContext db, int id)
        {
            var doctors = db.Doctor.Select(x => new {x.Id, x.Name}).Where(x => x.Id == id);
            return doctors;
        }

        public string AddComment(ApplicationContext db, Feedback feedback)
        {
            db.Feedback.Add(feedback);

            db.SaveChanges();

            return UserMessagesConstants.FeedBackAdded;
        }
    }
}