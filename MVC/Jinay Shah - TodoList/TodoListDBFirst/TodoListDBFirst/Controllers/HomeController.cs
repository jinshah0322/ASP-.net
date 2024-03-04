using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoListDBFirst.Models;

namespace TodoListProject.Controllers
{
    public class HomeController : Controller
    {
        TodoListMVCEntities db = new TodoListMVCEntities();
        public ActionResult Index()
        {
            var pendingTasks = db.Tasks.Where(model => model.IsCompleted == false).ToList();
            var completedTasks = db.Tasks.Where(model => model.IsCompleted == true).ToList();

            var data = new Tuple<List<TodoListDBFirst.Models.Task>, List<TodoListDBFirst.Models.Task>>(pendingTasks, completedTasks);

            return View(data);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Task e)
        {
            if (ModelState.IsValid == true)
            {

                if (db.Tasks.Where(model => model.TaskName == e.TaskName && model.IsCompleted == false).ToList().Count > 0)
                {
                    TempData["InsertMessage"] = "Task with same name already exists!!";
                }
                else
                {
                    db.Tasks.Add(e);
                    db.SaveChanges();
                    TempData["InsertMessage"] = "Task Added!!";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(int id)
        {
            if (id > 0)
            {
                var task = db.Tasks.Where(model => model.Id == id).FirstOrDefault();
                if (task != null)
                {
                    if (task.IsCompleted == false)
                    {
                        TempData["CompleteMessage"] = "Task Completed!!";
                        task.IsCompleted = true;
                    }
                    else
                    {
                        TempData["CompleteMessage"] = "Task Moved To Pending!!";
                        task.IsCompleted = false;
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row = db.Tasks.Where(model => model.Id == id).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    db.SaveChanges();
                    TempData["DeleteMessage"] = "Task Deleted Successfully!!";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShowTask(int id)
        {
            var Task = db.Tasks.Where(model => model.Id == id).FirstOrDefault();
            return View(Task);
        }

        public ActionResult Edit(int id)
        {
            var row = db.Tasks.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Task updated!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}