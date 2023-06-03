using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;
using TaskManagementPlatform2.Models;

namespace TaskManagementPlatform2.Controllers
{
    public class StatusesController : Controller
    {
        private readonly ApplicationDbContext db;
        public StatusesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var statuses = from status in db.Statuses
                           orderby status.Name
                           select status;
            ViewBag.Statuses = statuses;
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Status s)
        {
            try
            {
                db.Statuses.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Status status = db.Statuses.Find(id);
            ViewBag.Status = status;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Status requestedStatus)
        {
            Status status = db.Statuses.Find(id);
            try
            {
                status.Name = requestedStatus.Name;
                status.Color = requestedStatus.Color;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Edit", status.StatusId);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Status status = db.Statuses.Find(id);
            db.Statuses.Remove(status);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
