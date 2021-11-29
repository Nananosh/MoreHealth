using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IFeedBackService feedBackService;
        public FeedBackController(IFeedBackService feedBackService, ApplicationContext context)
        {
            this.feedBackService = feedBackService;
            db = context;
        }

        public IActionResult Index(int? department, int? specializations)
        { 
            SelectList departmers = new SelectList(GetAllDepartment(), "Id", "DepartmentName", department.HasValue ? department.Value : 1);
            ViewBag.DepartmentList = departmers;
            SelectList specialization = new SelectList(GetSpecializationsById(department.HasValue ? department.Value : 1), "Id", "SpecializationName");
            ViewBag.SpecialList = specialization;
            SelectList doctors = new SelectList(GetDoctorsBySpecializaton(specializations.HasValue ? specializations.Value : 1), "Id", "Name");
            ViewBag.DoctorList = doctors;
            return View();
        }

        public IActionResult GetSpecializatons(int id)
        {
            return PartialView(GetSpecializationsById(id));
        }

        public IActionResult GetDoctors(int id)
        {
            return PartialView(GetDoctorsBySpecializaton(id));
        }

        public IEnumerable<Specialization> GetAllSpecialization()
        {
            var specializations = feedBackService.GetAllSpecialization(db);
            
            return specializations;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            var departments = feedBackService.GetAllDepartment(db);

            return departments;
        }
        
        public IEnumerable<Specialization> GetSpecializationsById(int id)
        {
            var specializations = feedBackService.GetSpecializationsById(db, id);

            return specializations;
        }

        public IEnumerable<Doctor> GetDoctorsBySpecializaton(int id)
        {
            var doctors = feedBackService.GetDoctorsBySpecializaton(db, id);

            return doctors;
        }
    }
}
