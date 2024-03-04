using EFDBFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDBFirstApproach.Controllers
{
    public class SalaryController : Controller
    {
        EFCodeFirstEmployeeDBEntities1 db = new EFCodeFirstEmployeeDBEntities1();
        EFCodeFirstEmployeeDBEntities db1 = new EFCodeFirstEmployeeDBEntities();
        // GET: Salary
        public ActionResult Index()
        {
            var data = db.Salaries.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.Employees = db1.Employees.Select(e => e.EmployeeId).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Salary e)
        {
            if (ModelState.IsValid == true)
            {
                db.Salaries.Add(e);
                int success = db.SaveChanges();
                if (success > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted !!')</script>";
                    TempData["InsertMessage"] = "Data Inserted !!";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!')</script>";
                    ViewBag.InsertMessage = "Data Not Inserted !!";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Salaries.Where(model => model.SalaryId == id).FirstOrDefault();
            ViewBag.Employees = db1.Employees.Select(e => e.EmployeeId).ToList();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Salary e)
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
                var row = db.Salaries.Where(model => model.SalaryId == id).FirstOrDefault();
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
            var row = db.Salaries.Where(model => model.SalaryId == id).FirstOrDefault();
            return View(row);
        }
    }
}