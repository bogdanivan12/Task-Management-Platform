using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New(Comment comm)
        {
            comm.Date = DateTime.Now;
            comm.UserId = _userManager.GetUserId(User);
            try
            {
                db.Comments.Add(comm);
                db.SaveChanges();
                return Redirect("/Tasks/Show/" + comm.TaskId);
            }

            catch (Exception)
            {
                return Redirect("/Tasks/Show/" + comm.TaskId);
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Comment comm = db.Comments.Find(id);
            db.Comments.Remove(comm);
            db.SaveChanges();
            return Redirect("/Tasks/Show/" + comm.TaskId);
        }

        public IActionResult Edit(int id)
        {
            Comment comm = db.Comments.Find(id);
            ViewBag.Comment = comm;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Comment requestComment)
        {
            Comment comm = db.Comments.Find(id);
            try
            {

                comm.Content = requestComment.Content;

                db.SaveChanges();

                return Redirect("/Tasks/Show/" + comm.TaskId);
            }
            catch (Exception e)
            {
                return Redirect("/Tasks/Show/" + comm.TaskId);
            }

        }
    }
}
