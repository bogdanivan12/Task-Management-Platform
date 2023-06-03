using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;

namespace TaskManagementPlatform2.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext db;
        public TasksController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
