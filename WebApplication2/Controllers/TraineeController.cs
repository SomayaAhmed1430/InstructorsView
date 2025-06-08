using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TraineeController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
    }
}
