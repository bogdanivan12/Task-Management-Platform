using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext db;
        public TasksController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult New(Models.Task task)
        {
            task.Date = DateTime.Now;
            task.Deadline = DateTime.Now;

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
            Models.Task task = db.Tasks.Include("Status").Include("Comments")//.Include("Statuses")
                               .Where(pro => pro.TaskId == id)
                               .First();

            ViewBag.Task = task;

            //var statuses = from status in db.Statuses
            //               orderby status.Name
            //               select status;

            ViewBag.Status = task.Status;

            //ViewBag.Task = project.Tasks;

            // ViewBag.Category(ViewBag.UnNume) = article.Category (proprietatea Category);
            return View();
        }
    }
}
