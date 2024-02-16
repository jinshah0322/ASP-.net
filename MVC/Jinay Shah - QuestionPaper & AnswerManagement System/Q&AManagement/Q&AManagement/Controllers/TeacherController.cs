using Q_AManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        QandAEntities db = new QandAEntities();
        public ActionResult Index()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var questionPaper = db.QuestionPapers.Where(model => model.CreatorID == userID).ToList();
                return View(questionPaper);
            }
        }

        public ActionResult Create()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }


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
                    qp.Status = "Pending";
                    db.QuestionPapers.Add(qp);
                    db.SaveChanges();
                    Session["QuestionPaperID"] = qp.QuestionPaperID;
                    return RedirectToAction("AddQuestions");
                }
            }
            return View();
        }

        public ActionResult AddQuestions()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestions(Question q)
        {
            if (Session["QuestionPaperID"] != null)
            {
                q.QuestionPaperID = Convert.ToInt32(Session["QuestionPaperID"]);
                db.Questions.Add(q);
                db.SaveChanges();
                TempData["QuestionMessage"] = "Question Added Successfully!!";
                return RedirectToAction("AddQuestions");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

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

        public ActionResult DeleteQuestioPaper(int id)
        {
            if (id > 0)
            {
                var questionPaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
                if (questionPaper != null)
                {
                    var questions = db.Questions.Where(model=>model.QuestionPaperID == id).ToList();
                    if (questions.Count > 0)
                    {
                        foreach(var question in questions)
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

        public ActionResult ViewQuestionPaper(int id)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                TempData["QuestionPaperID"] = id;
                var QuestionPaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
                return View(QuestionPaper);
            }
        }

        public ActionResult viewQuestions(int id)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            { 
                var Question = db.Questions.Where(model => model.QuestionPaperID == id).FirstOrDefault();
                return View(Question);
            }
        }
    }
}