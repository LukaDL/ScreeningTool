using Microsoft.AspNetCore.Mvc;

namespace ScreeningTool.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
