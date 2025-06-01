using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InstructorController : Controller
    {
        Context context = new Context();
        // Instructor/Index
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View("Index", instructors);
        }

        // Instructor/Details/1
        public IActionResult Details(int id)
        {
            var inst = context.Instructors.FirstOrDefault(t => t.Id == id);

            if (inst == null)
                return NotFound();

            return View("Details", inst);
        }
    }
}
