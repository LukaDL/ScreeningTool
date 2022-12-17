using Microsoft.AspNetCore.Mvc;
using ScreeningTool.Data;
using ScreeningTool.Models;

namespace ScreeningTool.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuestionnaireController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            Question question = _db.Questions.FirstOrDefault(q => q.QuestionNumber== id);

            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }
    }
}
