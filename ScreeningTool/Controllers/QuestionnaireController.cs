using Microsoft.AspNetCore.Mvc;
using ScreeningTool.Data;
using ScreeningTool.Models;
using ScreeningTool.Models.ViewModels;

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
            QuestionnaireViewModel questionnaireViewModel= new QuestionnaireViewModel();
            questionnaireViewModel.Question = _db.Questions.FirstOrDefault(q => q.QuestionNumber== id);

            if (questionnaireViewModel.Question == null)
            {
                return NotFound();
            }
            return View(questionnaireViewModel);
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
