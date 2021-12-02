using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

namespace MoreHealth.Controllers
{
    public class PaidServicesController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IPaidServicesService paidServicesService;

        public PaidServicesController(ApplicationContext context,
            IPaidServicesService paidServicesService)
        {
            this.paidServicesService = paidServicesService;
            db = context;
        }

        // GET
        public IActionResult Index()
        {
            var paidServices = paidServicesService.GetAllPaidServices(db).ToList();
            return View(paidServices);
        }
    }
}