using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class TaskMembersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TaskMembersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New(TaskMember taskMember)
        {
            try
            {
                db.TaskMembers.Add(taskMember);
                db.SaveChanges();
                return Redirect("/Tasks/Show/" + taskMember.TaskId);
            }
            catch (Exception)
            {
                return Redirect("/Tasks/Show/" + taskMember.TaskId);
            }
        }

        [HttpPost]
        public IActionResult Delete(int taskId, string userId)
        {
            var taskMember = (from tm in db.TaskMembers
                              where tm.UserId == userId && tm.TaskId == taskId
                              select tm)
                             .First();
            db.TaskMembers.Remove(taskMember);
            db.SaveChanges();
            return Redirect("/Tasks/Show/" + taskMember.TaskId);
        }
    }
}
