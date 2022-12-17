using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScreeningTool.Data;
using ScreeningTool.Models;

namespace ScreeningTool.Controllers
{
    public class AccountController : Controller
    {
        /*
        private readonly ApplicationDbContext _db;
        UserManager<ScreeningTool.Models.ScreeningUser> _userManager;
        SignInManager<ScreeningTool.Models.ScreeningUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDbContext db, UserManager<ScreeningTool.Models.ScreeningUser> userManager,
            SignInManager<ScreeningTool.Models.ScreeningUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        } */

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
