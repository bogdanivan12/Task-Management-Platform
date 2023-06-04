using Microsoft.AspNetCore.Mvc;
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
    }
}
