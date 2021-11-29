using System.Collections.Generic;

using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IFeedBackService
    {
        IEnumerable<Doctor> GetAllDoctors(ApplicationContext db);

        IEnumerable<Specialization> GetAllSpecialization(ApplicationContext db);

        IEnumerable<Department> GetAllDepartment(ApplicationContext db);

        IEnumerable<Specialization> GetSpecializationsById(ApplicationContext db, int id);

        IEnumerable<Doctor> GetDoctorsBySpecializaton(ApplicationContext db, int id);
    }
}
