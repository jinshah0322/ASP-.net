using EFCodeFirstApproach.Models;
using EFCodeFirstApproachMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachMVC.Controllers
{
    public class DepartmentController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Department
        public ActionResult Index()
        {
            var data = db.Departments.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department d)
        {
            if(ModelState.IsValid == true)
            {
                db.Departments.Add(d);
                int success = db.SaveChanges();
                if (success > 0)
                {
                    TempData["InsertMessage"] = "Data Inserted !!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "Data Not Inserted !!";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Departments.Where(model => model.DepartmentId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Department e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                int success = db.SaveChanges();
                if (success > 0)
                {
                    TempData["UpdateMessage"] = "Data updated !!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "Data Not updated !!";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row = db.Departments.Where(model => model.DepartmentId == id).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    int success = db.SaveChanges();
                    if (success > 0)
                    {
                        TempData["DeleteMessage"] = "Data Deleted !!";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "Data Not Deleted !!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var row = db.Departments.Where(model => model.DepartmentId == id).FirstOrDefault();
            return View(row);
        }
    }
}