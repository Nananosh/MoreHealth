using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreHealth.ViewModels.Account;

namespace MoreHealth.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAppointmentService appointmentService;
        private readonly IAdminService adminService;

        public AdminController(
            IMapper mapper,
            IAppointmentService appointmentService,
            IAdminService adminService)
        {
            this.mapper = mapper;
            this.adminService = adminService;
            this.appointmentService = appointmentService;
        }

        public IActionResult AdminCabinet()
        {
            return View();
        }

        public IActionResult AdminAppointmentHome()
        {
            return View();
        }

        public IActionResult AdminDepartment()
        {
            return View();
        }

        public IActionResult AdminPaidService()
        {
            return View();
        }
        
        public IActionResult AdminSpecialization()
        {
            return View();
        }
        
        public IActionResult AdminDoctor()
        {
            return View();
        }
        
        public IActionResult AdminFeedback()
        {
            return View();
        }

        public IActionResult Doctor(int id)
        {
            ViewBag.DoctorId = id;
            return View();
        }

        public JsonResult GetAllCabinets()
        {
            var cabinets = adminService.GetAllCabinets();

            return Json(mapper.Map<IEnumerable<CabinetViewModel>>(cabinets));
        }

        public JsonResult GetAllAppointmentHome()
        {
            var appointmentHomes = adminService.GetAllAppointmentHome();

            return Json(mapper.Map<IEnumerable<AppointmentHomeViewModel>>(appointmentHomes));
        }

        public JsonResult GetAllPaidServices()
        {
            var paidServices = adminService.GetAllPaidServices();

            return Json(mapper.Map<IEnumerable<PaidServiceViewModel>>(paidServices));
        }

        public JsonResult GetAllDepartments()
        {
            var departments = adminService.GetAllDepartments();

            return Json(mapper.Map<IEnumerable<DepartmentViewModel>>(departments));
        }

        public JsonResult GetAllSpecializations()
        {
            var specializations = adminService.GetAllSpecializations();

            return Json(mapper.Map<IEnumerable<SpecializationViewModel>>(specializations));
        }

        public JsonResult GetAllFeedBacks()
        {
            var feedbacks = adminService.GetAllFeedBacks();

            return Json(mapper.Map<IEnumerable<FeedbackViewModel>>(feedbacks));
        }

        public JsonResult GetAllDoctors()
        {
            var doctors = adminService.GetAllDoctors();

            return Json(mapper.Map<IEnumerable<DoctorViewModel>>(doctors));
        }

        [HttpPost]
        public IActionResult UpdateCabinet(CabinetViewModel model)
        {
            var cabinet = adminService.UpdateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(cabinet));
        }

        [HttpPost]
        public IActionResult UpdatePaidService(PaidServiceViewModel model)
        {
            var paidServices = adminService.UpdatePaidService(mapper.Map<PaidServices>(model));

            return Json(mapper.Map<PaidServices>(paidServices));
        }

        [HttpPost]
        public IActionResult UpdateDepartment(DepartmentViewModel model)
        {
            var department = adminService.UpdateDepartment(mapper.Map<Department>(model));

            return Json(mapper.Map<DepartmentViewModel>(department));
        }

        [HttpPost]
        public IActionResult UpdateSpecialization(SpecializationViewModel model)
        {
            var specialization = adminService.UpdateSpecialization(mapper.Map<Specialization>(model));

            return Json(mapper.Map<SpecializationViewModel>(specialization));
        }

        [HttpPost]
        public IActionResult UpdateDoctor(DoctorViewModel model)
        {
            var doctor = adminService.UpdateDoctor(mapper.Map<Doctor>(model));

            return Json(mapper.Map<DoctorViewModel>(doctor));
        }

        [HttpPost]
        public IActionResult CreateCabinet(CabinetViewModel model)
        {
            var cabinet = adminService.CreateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(cabinet));
        }
        
        public JsonResult GetAppointmentsByDateFilter(string dateStart, string dateEnd, int doctorId)
        {
            DateTime dStart = DateTime.Parse(dateStart);
            DateTime dEnd = DateTime.Parse(dateEnd);
            var conclusions = adminService.GetAppointmentsByDateFilter(dStart, dEnd, doctorId);

            return Json(conclusions);
        }

        public JsonResult GetAppointmentsHomeByDateFilter(string dateStart, string dateEnd)
        {
            DateTime dStart = DateTime.Parse(dateStart);
            DateTime dEnd = DateTime.Parse(dateEnd);
            
            var conclusions = adminService.GetAppointmentsHomeByDateFilter(dStart, dEnd);

            return Json(conclusions);
        }
        
        [HttpPost]
        public IActionResult CreatePaidService(PaidServiceViewModel model)
        {
            var paidServices = adminService.CreatePaidService(mapper.Map<PaidServices>(model));

            return Json(mapper.Map<PaidServiceViewModel>(paidServices));
        }

        [HttpPost]
        public IActionResult CreateDepartment(DepartmentViewModel model)
        {
            var department = adminService.CreateDepartment(mapper.Map<Department>(model));

            return Json(mapper.Map<DepartmentViewModel>(department));
        }

        [HttpPost]
        public IActionResult CreateSpecialization(Specialization model)
        {
            var specialization = adminService.CreateSpecialization(mapper.Map<Specialization>(model));

            return Json(mapper.Map<SpecializationViewModel>(specialization));
        }

        [HttpDelete]
        public void RemoveCabinet(CabinetViewModel model)
        {
            adminService.RemoveCabinet(mapper.Map<Cabinet>(model));
        }

        [HttpDelete]
        public void RemovePaidService(PaidServiceViewModel model)
        {
            adminService.RemovePaidService(mapper.Map<PaidServices>(model));
        }

        [HttpDelete]
        public void RemoveDepartment(DepartmentViewModel model)
        {
            adminService.RemoveDepartment(mapper.Map<Department>(model));
        }

        [HttpDelete]
        public void RemoveSpecialization(SpecializationViewModel model)
        {
            adminService.RemoveSpecialization(mapper.Map<Specialization>(model));
        }

        [HttpDelete]
        public void RemoveDoctor(DoctorViewModel model)
        {
            adminService.RemoveDoctor(mapper.Map<Doctor>(model));
        }

        [HttpDelete]
        public void RemoveFeedBack(FeedbackViewModel model)
        {
            adminService.RemoveFeedBack(mapper.Map<Feedback>(model));
        }

        [HttpDelete]
        public void RemoveAppointmentHome(AppointmentHomeViewModel model)
        {
            adminService.RemoveAppointmentHome(mapper.Map<AppointmentHome>(model));
        }
    }
}