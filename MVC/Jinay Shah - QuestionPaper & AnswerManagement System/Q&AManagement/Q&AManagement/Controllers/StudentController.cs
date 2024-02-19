using Q_AManagement.Filter;
using Q_AManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    [CustomAuthorize]
    [StudentAuthorizationFilter]
    public class StudentController : Controller
    {
        // GET: Student
        QandAEntities db = new QandAEntities();
        public ActionResult Index()
        {

            var questionPaper = db.QuestionPapers.Where(model => model.Status == "Approved").ToList();
            return View(questionPaper);
        }

        public ActionResult ViewQuestionPaper(int id)
        {
            var QuestionPaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
            return View(QuestionPaper);
        }

        public ActionResult viewQuestions(int id)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
            return View(questions);
        }

        public ActionResult AnswerQuestionPaper(int id)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
            return View(questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerQuestionPaper(IEnumerable<Q_AManagement.Models.Question> questions)
        {
            if (questions == null || !questions.Any())
            {
                ModelState.AddModelError("", "No answers provided.");
                return RedirectToAction("AnswerQuestionPaper", new { id = questions.First().QuestionPaperID });
            }
            return View();
        }
    }
}