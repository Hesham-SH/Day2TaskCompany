using Day2TaskCompany.Models;
using Day2TaskCompany.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day2TaskCompany.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            List<RegistrationVM> registrationVMs = new List<RegistrationVM>();
            foreach (var user in users)
            {
                registrationVMs.Add(new RegistrationVM()
                {
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Sex = user.Sex,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Email = user.Email
                });
            }
            return View(registrationVMs);
        }

        public async Task<IActionResult> Profile()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            string userName = User.Identity.Name;
            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string Address = User.Claims.FirstOrDefault(c => c.Type == "Address").Value;
            string BirthDate = User.Claims.FirstOrDefault(c => c.Type == "BirthDate").Value;

            ProfileVM profileVM = new ProfileVM()
            {
                userName = userName,
                Address = Address,
                BirthDate = BirthDate
            };
            ApplicationUser user = await userManager.FindByIdAsync(id);
            return View("Profile1", profileVM);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = registrationVM.UserName,
                    PhoneNumber = registrationVM.PhoneNumber,
                    Sex = registrationVM.Sex,
                    Address = registrationVM.Address,
                    BirthDate = registrationVM.BirthDate,
                    Email = registrationVM.Email
                };
                var result = await userManager.CreateAsync(user, registrationVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registrationVM);
            }
            return View(registrationVM);
        }


    }
}
