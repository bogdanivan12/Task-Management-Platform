using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TeamMembersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New(TeamMember teamMember)
        {
            try
            {
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
                return Redirect("/Teams/Show/" + teamMember.TeamId);
            }
            catch (Exception)
            {
                return Redirect("/Teams/Show/" + teamMember.TeamId);
            }
        }

        [HttpPost]
        public IActionResult Delete(int teamId, string userId)
        {
            var teamMember = (from tm in db.TeamMembers
                             where tm.UserId == userId && tm.TeamId == teamId
                             select tm)
                             .First();
            db.TeamMembers.Remove(teamMember);
            db.SaveChanges();
            return Redirect("/Teams/Show/" + teamMember.TeamId);
        }
    }
}
