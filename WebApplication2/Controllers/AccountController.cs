using System.Security.Claims;
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

        #region Register
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
                IdentityResult result = await userManager.CreateAsync(user, UserVM.Password);  // success | fail
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
        #endregion

        #region LogIn
        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel logInVM)
        {
            if (ModelState.IsValid) 
            {
                // check if found
                ApplicationUser user = await userManager.FindByNameAsync(logInVM.UserName);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, logInVM.Password);
                    if (found) 
                    {
                        // cookie
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", user.Address));
                        await signInManager.SignInWithClaimsAsync(user, logInVM.RememberMe, claims);

                        //await signInManager.SignInAsync(user, logInVM.RememberMe); // id, name, role, email
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("LogIn", logInVM);
        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
        #endregion
    }
}
