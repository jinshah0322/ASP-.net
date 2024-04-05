using Q_AManagement.Filter;
using Q_AManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    //This is teacher controller
    [CustomAuthorize]
    [TeacherAuthorizationFilter]
    public class TeacherController : Controller
    {
        QandAEntities db = new QandAEntities();

        //This function is used to display the question paper created by respective teacher
        public ActionResult Index()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            var questionPaper = db.QuestionPapers.Where(model => model.CreatorID == userID).ToList();
            return View(questionPaper);
        }

        //This functions will display the view which is used to create the question paper
        public ActionResult Create()
        {
            return View();
        }

        //This function will accept the post request of teacher when they create the question paper by submiting it
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionPaper qp)
        {
            if (ModelState.IsValid == true)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                if (db.QuestionPapers.Where(model => model.Title == qp.Title && model.CreatorID == userID).ToList().Count > 0)
                {
                    TempData["CreateMessage"] = "QuestionPaper already exists";
                    return RedirectToAction("Create");
                }
                else
                {
                    qp.CreatorID = userID;
                    qp.Status = "Draft";
                    db.QuestionPapers.Add(qp);
                    db.SaveChanges();
                    Session["QuestionPaperID"] = qp.QuestionPaperID;
                    return RedirectToAction("AddQuestions");
                }
            }
            return View();
        }

        //This function is used to display the view to add questions to respective question paper
        public ActionResult AddQuestions()
        {
            return View();
        }

        //This function will accept post request of add questions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestions(Question q)
        {
            if (Session["QuestionPaperID"] != null)
            {
                q.QuestionPaperID = Convert.ToInt32(Session["QuestionPaperID"]);

                if (q.OptionA == null || q.OptionB == null || q.OptionC == null || q.OptionD == null)
                {
                    ModelState.AddModelError("", "All fields are mandetary.");
                    return View(q);
                }

                if (q.OptionA == q.OptionB || q.OptionA == q.OptionC || q.OptionA == q.OptionD ||
                    q.OptionB == q.OptionC || q.OptionB == q.OptionD || q.OptionC == q.OptionD)
                {
                    ModelState.AddModelError("", "Options cannot be the same.");
                    return View(q);
                }

                if (q.CorrectAnswer.ToLower() == q.OptionA.ToLower() || q.CorrectAnswer.ToLower() == q.OptionB.ToLower() ||
                    q.CorrectAnswer.ToLower() == q.OptionC.ToLower() || q.CorrectAnswer.ToLower() == q.OptionD.ToLower())
                {
                    db.Questions.Add(q);
                    db.SaveChanges();
                    TempData["QuestionMessage"] = "Question Added Successfully!!";
                    return RedirectToAction("AddQuestions");
                }
                else
                {
                    ModelState.AddModelError("", "Correct answer must match one of the options.");
                    return View(q);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //After adding the questions when there are no more questions to add teacher clicks on close questions so there this function is called
        public ActionResult closeQuestion()
        {
            if (Session["QuestionPaperID"] != null)
            {
                int questionpapaerid = Convert.ToInt32(Session["QuestionPaperID"]);
                var questions = db.Questions.Where(model => model.QuestionPaperID == questionpapaerid).ToList();
                if (!(questions.Count > 0))
                {
                    var row = db.QuestionPapers.Where(model => model.QuestionPaperID == questionpapaerid).FirstOrDefault();
                    if (row != null)
                    {
                        db.Entry(row).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        //This functions is called when teacher delets the question paper
        public ActionResult DeleteQuestioPaper(int id)
        {
            if (id > 0)
            {
                var questionPaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
                if (questionPaper != null)
                {
                    var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
                    if (questions.Count > 0)
                    {
                        var submissions = db.Submissions.Where(model => model.QuestionPaperID == id).ToList();
                        if (submissions.Count > 0)
                        {
                            foreach (var submisson in submissions)
                            {
                                db.Submissions.Remove(submisson);
                            }
                        }
                        foreach (var question in questions)
                        {
                            db.Questions.Remove(question);
                        }
                    }
                    db.Entry(questionPaper).State = EntityState.Deleted;
                    db.SaveChanges();
                    TempData["DeleteMessage"] = "Question Paper Deleted Successfully!!";
                }
            }
            return RedirectToAction("Index");
        }

        //This function is used to display all the question paper
        public ActionResult ViewQuestionPaper(int id)
        {
            var QuestionPaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
            return View(QuestionPaper);
        }

        //This function is used to display all the questions
        public ActionResult viewQuestions(int id)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
            Session["QuestionPaperID"] = id;
            var status = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault()?.Status;
            ViewBag.Status = status;
            return View(questions);
        }

        //This function is used to display all the edit question paper view
        public ActionResult EditQuestionPaper(int id)
        {
            var questionpaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
            if (questionpaper.Status == "Approved")
            {
                return RedirectToAction("ViewQuestionPaper", new { id = id });
            }
            else
            {
                return View(questionpaper);
            }
        }

        //This function is used when teacher posts question paper data and then edit it in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestionPaper(QuestionPaper qp)
        {
            if (ModelState.IsValid == true)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                qp.CreatorID = userID;
                qp.Status = "Draft";
                db.Entry(qp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Question Paper updated Successfully!!";
                return RedirectToAction("EditQuestionPaper");
            }
            return View();
        }

        //This function is used to display all the edit questions view
        public ActionResult EditQuestions(int qpid, int qid)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == qpid && model.QuestionID == qid).FirstOrDefault();
            Session["QuestionPaperID"] = qpid;
            return View(questions);
        }

        //This function is used when teacher posts questions data and then edit it in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestions(Question q)
        {
            if (ModelState.IsValid == true)
            {
                if (q.OptionA == null || q.OptionB == null || q.OptionC == null || q.OptionD == null)
                {
                    ModelState.AddModelError("", "All fields are mandetary.");
                    return View(q);
                }
                if (q.OptionA == q.OptionB || q.OptionA == q.OptionC || q.OptionA == q.OptionD ||
                    q.OptionB == q.OptionC || q.OptionB == q.OptionD || q.OptionC == q.OptionD)
                {
                    ModelState.AddModelError("", "Options cannot be the same.");
                    return View(q);
                }
                if (q.CorrectAnswer.ToLower() == q.OptionA.ToLower() || q.CorrectAnswer.ToLower() == q.OptionB.ToLower() ||
                    q.CorrectAnswer.ToLower() == q.OptionC.ToLower() || q.CorrectAnswer.ToLower() == q.OptionD.ToLower())
                {
                    q.QuestionPaperID = Convert.ToInt32(Session["QuestionPaperID"]);
                    db.Entry(q).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["UpdateMessage"] = "Task updated!!";
                    return RedirectToAction("viewQuestions", new { id = q.QuestionPaperID });
                }
                else
                {
                    ModelState.AddModelError("", "Correct answer must match one of the options.");
                    return View(q);
                }
            }
            return View();
        }

        //This functions is used to delete questions from a question paper
        public ActionResult DeleteQuestions(int qpid, int qid)
        {
            if (qid > 0)
            {
                var questions = db.Questions.Where(model => model.QuestionID == qid).FirstOrDefault();
                var submissions = db.Submissions.Where(model => model.QuestionID == qid).ToList();
                if (submissions.Count > 0)
                {
                    foreach (var submisson in submissions)
                    {
                        db.Submissions.Remove(submisson);
                    }
                }
                db.Entry(questions).State = EntityState.Deleted;
                db.SaveChanges();
                TempData["DeleteMessage"] = "Question Deleted Successfully!!";
            }
            return RedirectToAction("viewQuestions", new { id = qpid });
        }

        // Requests approval for a question paper by updating its status to "Pending" in the database.
        public ActionResult RequestApproval(int id)
        {
            var questionpaper = db.QuestionPapers.FirstOrDefault(model => model.QuestionPaperID == id);
            if (questionpaper != null)
            {
                questionpaper.Status = "Pending";
                db.SaveChanges();
            }
            return RedirectToAction("ViewQuestionPaper", new { id = id });
        }

        // Retrieves submissions related to question papers created by the current user and displays them.
        public ActionResult ViewSubmissions()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            var groupedQuery = (from submission in db.Submissions
                                join questionPaper in db.QuestionPapers on submission.QuestionPaperID equals questionPaper.QuestionPaperID
                                join user in db.Users on submission.UserID equals user.UserID
                                where questionPaper.CreatorID == userID
                                select new AllTableJoin
                                {
                                    Submissions = submission,
                                    QuestionPapers = questionPaper,
                                    Users = user
                                })
                    .GroupBy(x => new { x.Submissions.UserID, x.Submissions.QuestionPaperID });

            var query = groupedQuery.Select(g => g.FirstOrDefault());


            return View(query);
        }

        // Displays the score of a user for a specific question paper.
        public ActionResult ViewScore(int id,int userID)
        {
            var score = db.Submissions.Where(model => model.QuestionPaperID == id && model.isCorrect == true && model.UserID == userID).Count();
            var query = from submissions in db.Submissions
                        join questions in db.Questions on submissions.QuestionID equals questions.QuestionID
                        join questionPaper in db.QuestionPapers on submissions.QuestionPaperID equals questionPaper.QuestionPaperID
                        join user in db.Users on submissions.UserID equals user.UserID
                        where submissions.QuestionPaperID == id && submissions.UserID == userID
                        select new AllTableJoin
                        {
                            Questions = questions,
                            QuestionPapers = questionPaper,
                            Submissions = submissions,
                            Users = user,
                            Score = score
                        };
            return View(query.ToList());
        }
    }
}