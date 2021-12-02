using System.Collections.Generic;
using System.Linq;
using ItransitionCourseProject.ViewModels.Account;
using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IFeedBackService
    {
        IEnumerable<Doctor> GetAllDoctors(ApplicationContext db);

        IEnumerable<Specialization> GetAllSpecialization(ApplicationContext db);

        IEnumerable<Department> GetAllDepartment(ApplicationContext db);

        IEnumerable<Specialization> GetSpecializationsById(ApplicationContext db, int id);

        IQueryable GetDoctorsBySpecialization(ApplicationContext db, int id);

        string AddComment(ApplicationContext db, FeedbackViewModel feedbackViewModel);
    }
}