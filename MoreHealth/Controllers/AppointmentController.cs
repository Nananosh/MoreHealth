using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoreHealth.Business.Interfaces;
using MoreHealth.Constants.UserMessagesConstants;
using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IAppointmentService appointmentService;
        private readonly IDoctorOrPatientService doctorOrPatientService;
        private readonly IMapper mapper;

        public AppointmentController(ApplicationContext context, IMapper mapper,
            IAppointmentService appointmentService, IDoctorOrPatientService doctorOrPatientService)
        {
            this.appointmentService = appointmentService;
            db = context;
            this.doctorOrPatientService = doctorOrPatientService;
            this.mapper = mapper;
        }
        
        public JsonResult GetTalonsByDoctorDate(int? doctor, string talon1)
        {
            DateTime talon = DateTime.Parse(talon1);
            if (!doctor.HasValue)
            {
                return Json(null);
            }
            var talons = appointmentService.GetTalonsByDoctorDate(db, doctor.Value, talon);

            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }

        public IActionResult AddPatientTalon(int talon, string address, string userid)
        {
            var patientId = doctorOrPatientService.GetPatientByUserId(db, userid);

            var message = appointmentService.AddPatientTalon(db, talon, address, patientId);

            return Content(message);
        }

        public IActionResult CallingDoctorHome(string address, string userid)
        {
            var patientId = doctorOrPatientService.GetPatientByUserId(db, userid);

            var appointment = new AppointmentHomeViewModel() { Address = address, Date = DateTime.Now, PatientId = patientId };

            var messageToUser = appointmentService.CallingDoctorHome(db, mapper.Map<AppointmentHome>(appointment));

            return Content(messageToUser);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllTalons()
        {
            var talons = appointmentService.GetAllTalons(db);
            
            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }
    }
}