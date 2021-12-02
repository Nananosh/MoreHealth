using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using ItransitionCourseProject.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using MoreHealth.Business.Services;

namespace MoreHealth.Controllers
{
    [Authorize]
    public class FeedBackController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IFeedBackService feedBackService;
        private readonly IDoctorOrPatientService doctorOrPatientService;
        private readonly IMapper mapper;

        public FeedBackController(IFeedBackService feedBackService, ApplicationContext context, IMapper mapper,
            IDoctorOrPatientService doctorOrPatientService)
        {
            this.feedBackService = feedBackService;
            this.doctorOrPatientService = doctorOrPatientService;
            db = context;
            this.mapper = mapper;
        }

        public IActionResult Index(int? department, int? specializations)
        {
            return View();
        }

        public JsonResult GetAllSpecialization()
        {
            var specializations = feedBackService.GetAllSpecialization(db);

            return Json(specializations);
        }

        public IActionResult GetAllDepartment()
        {
            var departments = feedBackService.GetAllDepartment(db);

            return Json(mapper.Map<IEnumerable<DepartmentViewModel>>(departments));
        }

        public IActionResult GetSpecializationsById(int id)
        {
            var specializations = feedBackService.GetSpecializationsById(db, id);

            return Json(mapper.Map<IEnumerable<SpecializationViewModel>>(specializations));
            ;
        }

        public IActionResult GetDoctorsBySpecialization(int id)
        {
            var doctors = feedBackService.GetDoctorsBySpecialization(db, id);

            return Json(doctors);
        }

        [HttpPost]
        public IActionResult AddComment(byte isLike, int doctorId, string userId, string message)
        {
            var messageToUser = feedBackService.AddComment(db,
                new FeedbackViewModel
                {
                    DoctorId = doctorId, PatientId = doctorOrPatientService.GetPatientByUserId(db, userId),
                    IsLike = Convert.ToBoolean(isLike), Text = message
                });
            return Json(messageToUser);
        }
    }
}