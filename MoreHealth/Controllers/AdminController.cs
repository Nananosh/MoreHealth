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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppointmentHome()
        {
            return View();
        }

        public JsonResult GetAllCabinets()
        {
            var cabinets = adminService.GetAllCabinets();

            return Json(mapper.Map<IEnumerable<CabinetViewModel>>(cabinets));
        }

        public JsonResult GetAllAppointmentHome()
        {
            var appointmentHome = adminService.GetAllAppointmentHome();

            return Json(mapper.Map<IEnumerable<AppointmentHomeViewModel>>(appointmentHome));
        }

        [HttpPost]
        public IActionResult UpdateCabinet(CabinetViewModel model)
        {
            var cabinet = adminService.UpdateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(cabinet));
        }

        [HttpPost]
        public IActionResult CreateCabinet(CabinetViewModel model)
        {
            var cabinet = adminService.CreateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(cabinet));
        }

        [HttpDelete]
        public void RemoveCabinet(CabinetViewModel model)
        {
            adminService.RemoveCabinet(mapper.Map<Cabinet>(model));
        }

        public IActionResult RemoveAppointmentHome(AppointmentHomeViewModel model)
        {
            var messageToUser = adminService.RemoveAppointmentHome(model);

            return Content(messageToUser);
        }
    }
}
