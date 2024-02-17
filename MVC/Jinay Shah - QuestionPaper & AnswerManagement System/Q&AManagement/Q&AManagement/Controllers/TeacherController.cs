﻿using Q_AManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    [CustomAuthorize]
    public class TeacherController : Controller
    {
        QandAEntities db = new QandAEntities();
        public ActionResult Index()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            var questionPaper = db.QuestionPapers.Where(model => model.CreatorID == userID).ToList();
            return View(questionPaper);
        }

        public ActionResult Create()
        {
            return View();
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestions(Question q)
        {
            if (Session["QuestionPaperID"] != null)
            {
                q.QuestionPaperID = Convert.ToInt32(Session["QuestionPaperID"]);

                if(q.OptionA == null || q.OptionB == null || q.OptionC == null || q.OptionD == null)
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
                    var questions = db.Questions.Where(model => model.QuestionPaperID == id).ToList();
                    if (questions.Count > 0)
                    {
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

        public ActionResult EditQuestionPaper(int id)
        {
            var questionpaper = db.QuestionPapers.Where(model => model.QuestionPaperID == id).FirstOrDefault();
            return View(questionpaper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestionPaper(QuestionPaper qp)
        {
            if (ModelState.IsValid == true)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                qp.CreatorID = userID;
                qp.Status = "Pending";
                db.Entry(qp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Question Paper updated Successfully!!";
                return RedirectToAction("EditQuestionPaper");
            }
            return View();
        }

        public ActionResult EditQuestions(int id)
        {
            var questions = db.Questions.Where(model => model.QuestionID == id).FirstOrDefault();
            return View(questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestions(Question q)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(q).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Task updated!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}