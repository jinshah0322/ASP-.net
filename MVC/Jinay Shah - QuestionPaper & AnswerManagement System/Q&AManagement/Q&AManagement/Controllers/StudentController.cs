using Q_AManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        QandAEntities db = new QandAEntities();
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var questionPaper = db.QuestionPapers.Where(model=>model.Status == "Approved").ToList();
                return View(questionPaper);
            }
        }
    }
}