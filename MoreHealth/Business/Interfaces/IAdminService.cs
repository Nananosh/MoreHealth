using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Business.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Cabinet> GetAllCabinets();
        IEnumerable<AppointmentHome> GetAllAppointmentHome();
        IEnumerable<PaidServices> GetAllPaidServices();
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Specialization> GetAllSpecializations();
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Feedback> GetAllFeedBacks();
        Cabinet UpdateCabinet(Cabinet model);
        PaidServices UpdatePaidService(PaidServices paidServices);
        Department UpdateDepartment(Department department);
        Specialization UpdateSpecialization(Specialization specialization);
        Doctor UpdateDoctor(Doctor doctor);
        Feedback UpdateFeedBack(Feedback feedback);
        Cabinet CreateCabinet(Cabinet model);
        PaidServices CreatePaidService(PaidServices paidServices);
        Department CreateDepartment(Department department);
        Specialization CreateSpecialization(Specialization specialization);
        Doctor CreateDoctor(Doctor doctor);
        Feedback CreateFeedBack(Feedback feedback);
        void RemoveCabinet(Cabinet model);
        void RemoveAppointmentHome(AppointmentHome model);
        void RemovePaidService(PaidServices paidService);
        void RemoveDepartment(Department department);
        void RemoveSpecialization(Specialization specialization);
        void RemoveDoctor(Doctor doctor);
        void RemoveFeedBack(Feedback feedback);
        List<AppointmentHome> GetAppointmentsHomeByDateFilter(DateTime d1, DateTime d2);
        List<AppointmentViewModel> GetAppointmentsByDateFilter(DateTime d1, DateTime d2);
        
    }
}
