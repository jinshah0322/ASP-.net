using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Q_AManagement.Filter;
using Q_AManagement.Helpers;
using Q_AManagement.Models;


namespace Q_AManagement.Controllers
{
    // Controller for managing actions related to admins
    [CustomAuthorize]
    [AdminAuthorizationFilter]
    public class AdminController : Controller
    {
        private QandAEntities db = new QandAEntities();

        // Displays the index page for admins, listing approved question papers with their creators
        public ActionResult Index()
        {
            var query = from questionPaper in db.QuestionPapers
                        join user in db.Users on questionPaper.CreatorID equals user.UserID
                        where questionPaper.Status != "Draft"
                        select new QuestionPaperWithCreator
                        {
                            QuestionPaper = questionPaper,
                            CreatorName = user.Username
                        };

            return View(query.ToList());
        }

        // Displays the page for creating a new question paper
        public ActionResult CreateQuestionPaper()
        {
            return View();
        }

        // Handles the creation of a new question paper
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestionPaper(QuestionPaper qp)
        {
            if (ModelState.IsValid == true)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                if (db.QuestionPapers.Where(model => model.Title == qp.Title).ToList().Count > 0)
                {
                    TempData["CreateMessage"] = "QuestionPaper already exists";
                    return RedirectToAction("CreateQuestionPaper");
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

        // Displays the page for adding questions to a question paper
        public ActionResult AddQuestions()
        {
            return View();
        }

        // Handles the addition of questions to a question paper
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

        // Closes a question paper and deletes it if no questions are added
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

        // Deletes a question paper along with its associated questions and submissions
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

        // Displays details of a specific question paper
        public ActionResult ViewQuestionPaper(int id)
        {
            var query = from questionPaper in db.QuestionPapers
                        join user in db.Users on questionPaper.CreatorID equals user.UserID
                        where questionPaper.QuestionPaperID == id
                        select new QuestionPaperWithCreator
                        {
                            QuestionPaper = questionPaper,
                            CreatorName = user.Username
                        };
            return View(query.FirstOrDefault());
        }

        // Displays questions associated with a specific question paper
        public ActionResult viewQuestions(int id)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
            Session["QuestionPaperID"] = id;
            var status = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault()?.Status;
            ViewBag.Status = status;
            return View(questions);
        }

        // Displays the page for editing a question paper
        public ActionResult EditQuestionPaper(int id)
        {
            var questionpaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
            return View(questionpaper);
        }

        // Handles the editing of a question paper
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestionPaper(QuestionPaper qp)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(qp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Question Paper updated Successfully!!";
                return RedirectToAction("EditQuestionPaper");
            }
            return View();
        }

        // Displays the page for editing a specific question
        public ActionResult EditQuestions(int qpid, int qid)
        {
            var questions = db.Questions.Where(model => model.QuestionPaperID == qpid && model.QuestionID == qid).FirstOrDefault();
            Session["QuestionPaperID"] = qpid;
            return View(questions);
        }

        // Handles the editing of a specific question
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
                    TempData["UpdateMessage"] = "Question updated Successfully!!";
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

        // Deletes a question and its associated submissions
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

        // Displays a list of users
        public ActionResult Users()
        {
            return View(db.Users.ToList());
        }

        // Displays details of a specific user
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // Displays the page for creating a new user
        public ActionResult Create()
        {
            return View();
        }

        // Handles the creation of a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password,Email,Role")] User user)
        {
            PasswordEncryptionDecryption obj = new PasswordEncryptionDecryption();
            if (ModelState.IsValid)
            {
                user.Password = obj.EncryptString(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Users");
            }

            return View(user);
        }

        // Displays the page for editing a user
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // Handles the editing of a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password,Email,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Users");
            }
            return View(user);
        }

        // Displays the page for deleting a user
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // Deletes a user and all associated data (question papers, questions, and submissions)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                var questionPaper = db.QuestionPapers.Where(model => model.CreatorID == id).FirstOrDefault();
                if (questionPaper != null)
                {
                    var questions = db.Questions.Where(model => model.QuestionPaperID == questionPaper.QuestionPaperID).ToList();
                    if (questions.Count > 0)
                    {
                        int questionPaperID = Convert.ToInt32(questions.First().QuestionPaperID);
                        var submissions = db.Submissions.Where(model => model.QuestionPaperID == questionPaperID).ToList();
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
                }
                db.QuestionPapers.Remove(questionPaper);
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        // Displays submissions grouped by user and question paper
        public ActionResult ViewSubmissions()
        {
            var groupedQuery = (from submission in db.Submissions
                                join questionPaper in db.QuestionPapers on submission.QuestionPaperID equals questionPaper.QuestionPaperID
                                join user in db.Users on submission.UserID equals user.UserID
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

        // Displays the score of a user for a specific question paper
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

        // Deletes submissions associated with a specific question paper and user
        public ActionResult DeleteSubmission(int questioPaperid, int userid)
        {
            if (questioPaperid > 0)
            {
                var submissionsToDelete = db.Submissions.Where(model => model.QuestionPaperID == questioPaperid && model.UserID == userid);

                if (submissionsToDelete != null)
                {
                    db.Submissions.RemoveRange(submissionsToDelete);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewSubmissions");
            }
            return RedirectToAction("ViewSubmissions");
        }

        // Disposes of the database context when the controller is disposed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
