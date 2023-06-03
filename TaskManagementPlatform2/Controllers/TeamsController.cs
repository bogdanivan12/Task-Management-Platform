using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;

namespace TaskManagementPlatform2.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext db;
        public TeamsController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
