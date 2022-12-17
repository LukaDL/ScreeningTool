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
        private readonly SignInManager<ScreeningUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public AccountController(UserManager<ScreeningUser> userManager, SignInManager<ScreeningUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            //var user = await _userManager.FindByNameAsync(loginViewModel.Email);

            if (user != null)
            {
                // User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if(passwordCheck)
                {
                    // Password correct, sign in.
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Questionnaire", new {@id=1});
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
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if(user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new ScreeningUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            /*
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, isPersistent: false);

            }
            */

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }
    }
}
