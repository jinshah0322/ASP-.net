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
            int userID = Convert.ToInt16(Session["UserID"]);

            var query = from questionPaper in db.QuestionPapers
                        where questionPaper.Status == "Approved"
                        join submission in db.Submissions.Where(s => s.UserID == userID)
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
                var questionId = Convert.ToInt16(Answer.GetKey(i));
                var tickedAnswer = Answer[i];
                var correctAnswer = db.Questions.Where(model=>model.QuestionID == questionId).FirstOrDefault().CorrectAnswer.ToString();
                bool iscorrect;
                if(correctAnswer == tickedAnswer) iscorrect= true;
                else iscorrect= false;
                var submission = new Submission
                {
                    UserID = Convert.ToInt32(Session["UserID"]),
                    QuestionPaperID = questionPaperId,
                    QuestionID =questionId,
                    TickedAnswer = tickedAnswer,
                    SubmissionDate = DateTime.Now,
                    isCorrect = iscorrect
                };
                db.Submissions.Add(submission);
            }

            TempData["examSubmitted"] = "You have successfully submitted the exam!!";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ViewScore(int id) 
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var score = db.Submissions.Where(model=>model.QuestionPaperID == id && model.isCorrect == true && model.UserID == userId).Count();
            var query = from questions in db.Questions
                        join submissions in db.Submissions on questions.QuestionID equals submissions.QuestionID
                        where submissions.QuestionPaperID == id && submissions.UserID == userId
                        select new AllTableJoin
                        {
                            Questions = questions,
                            Submissions = submissions,
                            Score = score
                        };
            return View(query.ToList());
        }
    }
}