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
        private readonly IAppointmentService appointmentService;
        private readonly IMapper mapper;

        public AppointmentController(ApplicationContext context, IMapper mapper,
            IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
            db = context;
            this.mapper = mapper;
        }

        public IActionResult GetAllTalons()
        {
            var talons = appointmentService.GetAllTalons(db);
            
            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }
    }
}