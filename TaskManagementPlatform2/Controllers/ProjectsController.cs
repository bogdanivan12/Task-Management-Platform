using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;

namespace TaskManagementPlatform2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProjectsController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var projects = from project in db.Projects
                           orderby project.Deadline
                           select project;
            ViewBag.Projects = projects;
            return View();
        }
    }
}
