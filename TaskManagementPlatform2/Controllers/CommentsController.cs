using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform2.Data;

namespace TaskManagementPlatform2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext db;
        public CommentsController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
