using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TasksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var tasks = db.Tasks.Include("Status");
                ViewBag.Tasks = tasks;
            }
            else
            {
                var tasks = from task in db.Tasks
                            join taskMember in db.TaskMembers on task.TaskId equals taskMember.TaskId
                            where taskMember.UserId == _userManager.GetUserId(User)
                            select task;
                ViewBag.Tasks = tasks.Concat(from task in db.Tasks
                                             where task.UserId == _userManager.GetUserId(User)
                                             select task).Distinct().Include("Status").OrderBy(t => t.Deadline);
            }
            return View();
        }

        [HttpPost]
        public IActionResult New(Models.Task task)
        {
            task.Date = DateTime.Now;
            //task.Deadline = DateTime.Now;
            task.UserId = _userManager.GetUserId(User);
            try
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return Redirect("/Projects/Show/" + task.ProjectId);
            }
            catch (Exception)
            {
                return Redirect("/Projects/Show/" + task.ProjectId);
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Models.Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return Redirect("/Projects/Show/" + task.ProjectId);
        }

        public IActionResult Edit(int id)
        {
            Models.Task task = db.Tasks.Find(id);
            var statuses = from status in db.Statuses
                           orderby status.Name
                           select status;

            ViewBag.AppUserId = _userManager.GetUserId(User);

            ViewBag.Statuses = statuses;
            ViewBag.Task = task;
            ViewBag.StatusId = task.StatusId;
            return View();

            //Models.Task task = db.Tasks.Find(id);
            //ViewBag.Task = task;
            //return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Models.Task requestTask)
        {
            Models.Task task = db.Tasks.Find(id);

            try
            {

                task.Name = requestTask.Name;
                task.Description = requestTask.Description;
                task.StatusId = requestTask.StatusId;

                db.SaveChanges();

                return Redirect("/Projects/Show/" + task.ProjectId);
            }
            catch (Exception e)
            {
                return Redirect("/Projects/Show/" + task.ProjectId);
            }

        }
        public IActionResult Show(int id)
        {
            ViewBag.AppUserId = _userManager.GetUserId(User);

            Models.Task task = db.Tasks.Include("Status")//.Include("Comments")//.Include("Statuses")
                               .Where(pro => pro.TaskId == id)
                               .First();

            ViewBag.Task = task;

            var comments = db.Comments.Include("User")
                .Where(com => com.TaskId == id);
            ViewBag.Comments = comments;

            //var statuses = from status in db.Statuses
            //               orderby status.Name
            //               select status;

            ViewBag.Status = task.Status;

            var users = from t in db.Tasks
                        join p in db.Projects on t.ProjectId equals p.ProjectId
                        join team in db.Teams on p.TeamId equals team.TeamId
                        join teamMember in db.TeamMembers on team.TeamId equals teamMember.TeamId
                        join user in db.Users on teamMember.UserId equals user.Id
                        where t.TaskId == id
                        orderby user.UserName
                        select user;
            ViewBag.Users = users;

            var members = from t in db.Tasks
                          join tm in db.TaskMembers on t.TaskId equals tm.TaskId
                          where t.TaskId == id
                          select tm.User;
            ViewBag.Members = members.Distinct();


            //ViewBag.Task = project.Tasks;

            // ViewBag.Category(ViewBag.UnNume) = article.Category (proprietatea Category);
            return View();
        }
    }
}
