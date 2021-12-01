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

namespace MoreHealth.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IFeedBackService feedBackService;
        private readonly IMapper mapper;
        public FeedBackController(IFeedBackService feedBackService, ApplicationContext context,IMapper _mapper)
        {
            this.feedBackService = feedBackService;
            db = context;
            mapper = _mapper;
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

            return Json(mapper.Map<IEnumerable<SpecializationViewModel>>(specializations));;
        }

        public IActionResult GetDoctorsBySpecialization(int id)
        {
            var doctors = feedBackService.GetDoctorsBySpecialization(db, id);

            return Json(doctors);
        }

        [HttpPost]
        public IActionResult AddComment(bool isLike, int doctorId, string message)
        {
            var messageToUser = feedBackService.AddComment(db, isLike, doctorId, message);

            return Json(messageToUser);
        }
    }
}
