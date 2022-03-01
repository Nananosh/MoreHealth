using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Business.Interfaces;
using MoreHealth.Constants.UserMessagesConstants;
using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public AdminService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.db = context;
        }

        public IEnumerable<Cabinet> GetAllCabinets()
        {
            var cabinets = db.Cabinet;

            return cabinets;
        }

        public IEnumerable<AppointmentHome> GetAllAppointmentHome()
        {
            var appointmentHome = db.AppointmentHomes
                .Include(ah => ah.Patient);

            return appointmentHome;
        }

        public IEnumerable<PaidServices> GetAllPaidServices()
        {
            var paidServices = db.PaidServices;

            return paidServices;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            var departments = db.Department;

            return departments;
        }

        public IEnumerable<Specialization> GetAllSpecializations()
        {
            var specializations = db.Specialization
                .Include(x => x.Department);

            return specializations;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = db.Doctor
                .Include(x => x.Cabinet)
                .Include(x => x.Specialization);

            return doctors;
        }

        public IEnumerable<Feedback> GetAllFeedBacks()
        {
            var feedBack = db.Feedback
                .Include(x => x.Doctor);

            return feedBack;
        }

        public Cabinet UpdateCabinet(Cabinet model)
        {
            var cabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            if (cabinet != null)
            {
                cabinet.CabinetNumber = model.CabinetNumber;

                db.SaveChanges();
            }

            var updatedCabinet = db.Cabinet.FirstOrDefault(c => c.Id == cabinet.Id);

            return updatedCabinet;
        }

        public PaidServices UpdatePaidService(PaidServices paidServices)
        {
            var updatePaidService = db.PaidServices.FirstOrDefault(x => x.Id == paidServices.Id);
            if (updatePaidService != null)
            {
                updatePaidService.Description = paidServices.Description;
                updatePaidService.Price = paidServices.ForeignPrice;
                updatePaidService.ForeignPrice = paidServices.ForeignPrice;
                updatePaidService.ServiceName = paidServices.ServiceName;

                db.SaveChanges();
            }

            var updatedPaidService = db.PaidServices.FirstOrDefault(x => x.Id == updatePaidService.Id);

            return updatedPaidService;
        }

        public Department UpdateDepartment(Department department)
        {
            var updateDepartment = db.Department.FirstOrDefault(x => x.Id == department.Id);
            if (updateDepartment != null)
            {
                updateDepartment.DepartmentName = department.DepartmentName;
                db.SaveChanges();
            }

            var updatedDepartment = db.Department.FirstOrDefault(x => x.Id == updateDepartment.Id);

            return updatedDepartment;
        }

        public Specialization UpdateSpecialization(Specialization specialization)
        {
            var updateSpecialization = db.Specialization.FirstOrDefault(x => x.Id == specialization.Id);
            if (updateSpecialization != null)
            {
                updateSpecialization.SpecializationName = specialization.SpecializationName;
                updateSpecialization.DepartmentId = specialization.DepartmentId;
                db.SaveChanges();
            }

            var updatedSpecialization = db.Specialization
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Id == specialization.Id);

            return updatedSpecialization;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var updateDoctor = db.Doctor.FirstOrDefault(x => x.Id == doctor.Id);
            if (updateDoctor != null)
            {
                updateDoctor.Name = doctor.Name;
                updateDoctor.Surname = doctor.Surname;
                updateDoctor.LastName = doctor.LastName;
                updateDoctor.CabinetId = doctor.CabinetId;
                updateDoctor.SpecializationId = doctor.SpecializationId;
                updateDoctor.EndWorkTimeEvenDay = doctor.EndWorkTimeEvenDay;
                updateDoctor.EndWorkTimeOddDay = doctor.EndWorkTimeOddDay;
                updateDoctor.StartWorkTimeEvenDay = doctor.StartWorkTimeEvenDay;
                updateDoctor.StartWorkTimeOddDay = doctor.StartWorkTimeOddDay;
                updateDoctor.Weekend = doctor.Weekend;
                db.SaveChanges();
            }

            var updatedDoctor = db.Doctor
                .Include(x => x.Cabinet)
                .Include(x => x.Specialization)
                .FirstOrDefault(x => x.Id == updateDoctor.Id);

            return updatedDoctor;
        }

        public Feedback UpdateFeedBack(Feedback feedback)
        {
            var updateFeedBack = db.Feedback.FirstOrDefault(x => x.Id == feedback.Id);
            if (updateFeedBack != null)
            {
                updateFeedBack.Text = feedback.Text;
                updateFeedBack.Rating = feedback.Rating;
                updateFeedBack.DoctorId = feedback.DoctorId;
                updateFeedBack.PatientId = feedback.PatientId;
                db.SaveChanges();
            }

            var updatedFeedBack = db.Feedback
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .FirstOrDefault(x => x.Id == updateFeedBack.Id);

            return updatedFeedBack;
        }

        public Cabinet CreateCabinet(Cabinet model)
        {
            if (model != null)
            {
                db.Cabinet.Add(model);
                db.SaveChanges();
            }

            var addedCabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            return addedCabinet;
        }

        public PaidServices CreatePaidService(PaidServices paidServices)
        {
            if (paidServices != null)
            {
                db.PaidServices.Add(paidServices);
                db.SaveChanges();
            }

            var addedPaidService = db.PaidServices.FirstOrDefault(x => x.Id == paidServices.Id);

            return addedPaidService;
        }
        
        public List<AppointmentViewModel> GetAppointmentsByDateFilter(DateTime d1, DateTime d2)
        {
            var appointments = db.Appointments
                .Where(x => x.DateStart >= d1 && x.DateStart <= d2 && x.PatientId != null)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Specialization)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Cabinet)
                .ToList();

            return mapper.Map<List<AppointmentViewModel>>(appointments);
        }

        public List<AppointmentHome> GetAppointmentsHomeByDateFilter(DateTime d1, DateTime d2)
        {
            var appointments = db.Appointments
                .Where(x => x.DateStart >= d1 && x.DateStart <= d2)
                .Include(x => x.Doctor)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Specialization)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Cabinet)
                .ToList();

            return mapper.Map<List<AppointmentHome>>(appointments);
        }
        
        public Department CreateDepartment(Department department)
        {
            if (department != null)
            {
                db.Department.Add(department);
                db.SaveChanges();
            }

            var addedDepartment = db.Department.FirstOrDefault(x => x.Id == department.Id);

            return addedDepartment;
        }

        public Specialization CreateSpecialization(Specialization specialization)
        {
            if (specialization != null)
            {
                db.Specialization.Add(specialization);
                db.SaveChanges();
            }

            var addedSpecialization = db.Specialization
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Id == specialization.Id);

            return addedSpecialization;
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
            }

            var addedDoctor = db.Doctor
                .Include(x => x.Specialization)
                .Include(x => x.Cabinet)
                .FirstOrDefault(x => x.Id == doctor.Id);

            return addedDoctor;
        }

        public Feedback CreateFeedBack(Feedback feedback)
        {
            if (feedback != null)
            {
                db.Feedback.Add(feedback);
                db.SaveChanges();
            }

            var addedFeedback = db.Feedback
                .Include(x => x.Doctor)
                .FirstOrDefault(x => x.Id == feedback.Id);

            return addedFeedback;
        }

        public void RemoveCabinet(Cabinet model)
        {
            var removeCabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            if (removeCabinet != null)
            {
                db.Cabinet.Remove(removeCabinet);
                db.SaveChanges();
            }
        }

        public void RemoveAppointmentHome(AppointmentHome model)
        {
            var appointmentHome = db.AppointmentHomes.FirstOrDefault(ah => ah.Id == model.Id);

            if (appointmentHome != null)
            {
                db.AppointmentHomes.Remove(appointmentHome);
                db.SaveChanges();
            }
        }

        public void RemovePaidService(PaidServices paidService)
        {
            var removePaidService = db.PaidServices.FirstOrDefault(x => x.Id == paidService.Id);
            if (removePaidService != null)
            {
                db.PaidServices.Remove(removePaidService);
                db.SaveChanges();
            }
        }

        public void RemoveDepartment(Department department)
        {
            var removeDepartment = db.Department.FirstOrDefault(x => x.Id == department.Id);
            if (removeDepartment != null)
            {
                db.Department.Remove(removeDepartment);
                db.SaveChanges();
            }
        }

        public void RemoveSpecialization(Specialization specialization)
        {
            var removeSpecialization = db.Specialization.FirstOrDefault(x => x.Id == specialization.Id);
            if (removeSpecialization != null)
            {
                db.Specialization.Remove(removeSpecialization);
                db.SaveChanges();
            }
        }

        public void RemoveDoctor(Doctor doctor)
        {
            var removeDoctor = db.Doctor.Include(u => u.User).FirstOrDefault(x => x.Id == doctor.Id);
            var removeUser = db.Users.FirstOrDefault(x => x.Id == removeDoctor.User.Id);
            var removeFeedback = db.Feedback.Where(x => x.DoctorId == removeDoctor.Id);
            var removeAppointments = db.Appointments.Where(x => x.Doctor.Id == removeDoctor.Id);
            if (removeDoctor != null)
            {
                db.Appointments.RemoveRange(removeAppointments);
                db.Feedback.RemoveRange(removeFeedback);
                db.Doctor.Remove(removeDoctor);
                db.SaveChanges();
                db.Users.Remove(removeUser);
                db.SaveChanges();
            }
        }

        public void RemoveFeedBack(Feedback feedback)
        {
            var removeFeedback = db.Feedback.FirstOrDefault(x => x.Id == feedback.Id);
            if (removeFeedback != null)
            {
                db.Feedback.Remove(removeFeedback);
                db.SaveChanges();
            }
        }
    }
}