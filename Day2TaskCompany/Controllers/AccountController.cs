using Day2TaskCompany.Models;
using Day2TaskCompany.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day2TaskCompany.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    bool valid = await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (valid)
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim("Address",user.Address),
                            new Claim("BirthDate",user.BirthDate.ToString())
                        };

                        await signInManager.SignInWithClaimsAsync(user, loginVM.RememberMe, claims);
                        return RedirectToAction("Profile", "User");
                    }

                }
                ModelState.AddModelError("", "Wrong Email Or Password");
                return View(loginVM);
            }
            return View(loginVM);
        }
        public async Task<IActionResult> Logout(LoginVM loginVM)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
