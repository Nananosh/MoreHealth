using Microsoft.AspNetCore.Mvc;

namespace MoreHealth.Controllers
{
    public class ScheduleController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}