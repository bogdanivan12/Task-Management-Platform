using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var teams = from team in db.Teams
                        orderby team.Name
                        select team;
            ViewBag.Teams = teams;
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Team t)
        {
            try
            {
                db.Teams.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Show(int id)
        {
            Team team = db.Teams.Find(id);
            ViewBag.Team = team;

            var projects = from project in db.Projects
                           orderby project.Name
                           where project.TeamId == id
                           select project;
            ViewBag.Projects = projects;
            return View();
        }

        public IActionResult Edit(int id)
        {
            Team team = db.Teams.Find(id);
            ViewBag.Team = team;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Team requestedTeam)
        {
            Team team = db.Teams.Find(id);
            try
            {
                team.Name = requestedTeam.Name;
                db.SaveChanges();
                return Redirect("/Teams/Show/" + team.TeamId);
            }
            catch (Exception)
            {
                return RedirectToAction("Edit", team.TeamId);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
