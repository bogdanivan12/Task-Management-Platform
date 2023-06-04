using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProjectsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var projects = from project in db.Projects
                               orderby project.Deadline
                               select project;

                ViewBag.Projects = projects;
            }
            else
            {
                var projects = from project in db.Projects
                               orderby project.Deadline
                               where project.UserId == _userManager.GetUserId(User)
                               select project;

                ViewBag.Projects = projects;
            }
            return View();
        }

        public IActionResult Show(int id)
        {
            Project project = db.Projects.Include("Tasks")//.Include("Statuses")
                               .Where(pro => pro.ProjectId == id)
                               .First();

            ViewBag.Project = project;

            var statuses = from status in db.Statuses
                              orderby status.Name
                              select status;

            ViewBag.Statuses = statuses;

            //ViewBag.Task = project.Tasks;

            // ViewBag.Category(ViewBag.UnNume) = article.Category (proprietatea Category);
            return View();
        }

        public IActionResult New()
        {
            var teams = from team in db.Teams
                        orderby team.Name
                        select team;

            ViewBag.Teams = teams;

            return View();
        }

        // Se adauga articolul in baza de date
        [HttpPost]
        public IActionResult New(Project project)
        {
            project.UserId = _userManager.GetUserId(User);
            try
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (Exception)
            {
                return RedirectToAction("New");
            }
        }

        public IActionResult Edit(int id)
        {
            Project project = db.Projects.Include("Team")
                                         .Where(proj => proj.ProjectId == id)
                                         .First();

            if (!User.IsInRole("Admin") && project.UserId != _userManager.GetUserId(User))
            {
                return Redirect("/Identity/Account/AccessDenied");
            }

            ViewBag.Project = project;
            ViewBag.Team = project.Team;

            var teams = from team in db.Teams
                        select team;

            ViewBag.Teams = teams;

            return View();
        }

        // Se adauga articolul modificat in baza de date
        [HttpPost]
        public IActionResult Edit(int id, Project requestProject)
        {
            Project project = db.Projects.Find(id);

            try
            {
                {
                    project.Name = requestProject.Name;
                    project.Description = requestProject.Description;
                    project.Date = requestProject.Date;
                    project.Deadline = requestProject.Deadline;
                    project.TeamId = requestProject.TeamId;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            catch (Exception)
            {
                return RedirectToAction("Edit", id);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
