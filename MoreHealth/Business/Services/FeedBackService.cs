using System.Collections.Generic;
using System.Linq;
using ItransitionCourseProject.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

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

        public string AddComment(ApplicationContext db, FeedbackViewModel feedbackViewModel)
        {
            db.Feedback.Add(
                new Feedback
                {
                    DoctorId = feedbackViewModel.Doctor.Id,
                    IsLike = feedbackViewModel.IsLike,
                    Text = feedbackViewModel.Text,
                    PatientId = feedbackViewModel.Patient.Id
                });

            db.SaveChanges();
            return "Отзыв добавлен!";
        }
    }
}