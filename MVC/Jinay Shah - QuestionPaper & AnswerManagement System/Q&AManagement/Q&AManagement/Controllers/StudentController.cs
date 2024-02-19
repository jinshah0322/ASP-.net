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
            var query = from questionPaper in db.QuestionPapers
                        where questionPaper.Status == "Approved"
                        join submission in db.Submissions
                        on questionPaper.QuestionPaperID equals submission.QuestionPaperID into submissionGroup
                        from submission in submissionGroup.DefaultIfEmpty()
                        select new QuestionPaperWithSubmission
                        {
                            QuestionPaper = questionPaper,
                            Submission = submission
                        };

            var distinctQuery = query.GroupBy(q => q.QuestionPaper.QuestionPaperID)
                                      .Select(g => g.FirstOrDefault());

            var result = distinctQuery.ToList();
            return View(result);
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
            ViewBag.QuestionPaperId = id;
            var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
            return View(questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerQuestionPaper(int questionPaperId, FormCollection Answer)
        {
            for (int i = 1; i < Answer.Count; i++)
            {
                var key = Answer.GetKey(i);
                var parts = key.Split('|');
                if (parts.Length == 2)
                {
                    var questionId = Convert.ToInt32(parts[0]);
                    var selectedOption = parts[1];

                    var submission = new Submission
                    {
                        UserID = Convert.ToInt32(Session["UserID"]),
                        QuestionPaperID = questionPaperId,
                        QuestionID = questionId,
                        TickedAnswer = selectedOption,
                        SubmissionDate = DateTime.Now
                    };
                    db.Submissions.Add(submission);
                }
            }

            TempData["examSubmitted"] = "You have successfully submitted the exam!!";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}