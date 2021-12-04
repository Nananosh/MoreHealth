using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoreHealth.Business.Interfaces;
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
        private readonly IFeedBackService feedBackService;
        private readonly IDoctorOrPatientService doctorOrPatientService;
        private readonly IMapper mapper;

        public AppointmentController(IFeedBackService feedBackService, ApplicationContext context, IMapper mapper,
            IDoctorOrPatientService doctorOrPatientService)
        {
            this.feedBackService = feedBackService;
            this.doctorOrPatientService = doctorOrPatientService;
            db = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllTalons()
        {
            var talons = feedBackService.GetAllTalons(db);

            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }
    }
}
