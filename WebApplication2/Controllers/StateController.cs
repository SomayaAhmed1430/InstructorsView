using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class StateController : Controller
    {
        // state/setsession?name=value&age=value
        public IActionResult SetSession(string name, int age) 
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content($"Session Save");
        }
        // state/getsession
        public IActionResult GetSession()
        {
            string n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"{n}\t{a}");
        }
    
        
        public IActionResult SetCookie(string name, int age)
        {
            // session cookie
            HttpContext.Response.Cookies.Append("Name", name);
            // presestant cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Age", age.ToString(), options);
            return Content($"Cookie Save");
        }
        public IActionResult GetCookie(string name)
        {
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"Cookie Name:{n}, Age: {a}");
        }
    }
}
