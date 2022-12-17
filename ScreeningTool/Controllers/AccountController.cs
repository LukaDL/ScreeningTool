using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScreeningTool.Data;
using ScreeningTool.Models;
using ScreeningTool.Models.ViewModels;

namespace ScreeningTool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ScreeningUser> _userManager;
        private readonly SignInManager<ScreeningUser> __signInManager;
        private readonly ApplicationDbContext _db;

        public AccountController(UserManager<ScreeningUser> userManager, SignInManager<ScreeningUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            __signInManager = signInManager;
            _db = db;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(user != null)
            {
                // User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if(passwordCheck)
                {
                    // Password correct, sign in.
                    var result = await __signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Questionnaire", 1);
                    }
                }
                // Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }

            // User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
