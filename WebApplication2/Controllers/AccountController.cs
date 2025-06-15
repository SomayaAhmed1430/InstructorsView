using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel UserVM)
        {
            if (ModelState.IsValid) 
            {
                // create account
                //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>();  ==> ask in ctor
                ApplicationUser user = new ApplicationUser()
                {
                    UserName       = UserVM.UserName,
                    PasswordHash   = UserVM.Password,
                    Address        = UserVM.Address,
                };
                IdentityResult result = await userManager.CreateAsync(user);  // success | fail
                if (result.Succeeded)
                {
                    // create cookie with specific claim(id - name - [email] - [role])
                    //SignInManager<ApplicationUser> signInManager = new SignInManager<ApplicationUser>();  ==> ask in ctor
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("Register", UserVM);
        }
    }
}
