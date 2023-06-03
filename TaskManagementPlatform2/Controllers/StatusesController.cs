using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;

namespace TaskManagementPlatform2.Controllers
{
    public class StatusesController : Controller
    {
        private readonly ApplicationDbContext db;
        public StatusesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var statuses = from status in db.Statuses
                           orderby status.Name
                           select status;
            ViewBag.Statuses = statuses;
            return View();
        }
    }
}
