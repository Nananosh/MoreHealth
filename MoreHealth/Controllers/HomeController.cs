using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

namespace MoreHealth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;
        private readonly IAppointmentService appointmentService;
        private readonly IDoctorOrPatientService doctorOrPatientService;
        public HomeController(ILogger<HomeController> logger,
            ApplicationContext context, 
            IDoctorOrPatientService doctorOrPatientService,
            IAppointmentService appointmentService)
        {
            _logger = logger;
            this.appointmentService = appointmentService;
            this.doctorOrPatientService = doctorOrPatientService;
            db = context;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Doctor> doctors = db.Doctor;
            return View(doctors);
        }

        public IActionResult DoctorWorkTime(string id)
        {
            if (id == null) return RedirectToAction("Index");
            
            var doctorId = doctorOrPatientService.GetDoctorByUserId(db, id);
            var doctor = appointmentService.GetDoctorById(doctorId);
            
            if (doctor == null) return RedirectToAction("Index");
            
            return View(doctor);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}