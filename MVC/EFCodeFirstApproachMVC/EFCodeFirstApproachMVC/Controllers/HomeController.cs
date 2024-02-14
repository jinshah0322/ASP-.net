using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApproach.Models;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;

namespace EFCodeFirstApproachMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // Get: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                db.Employees.Add(e);
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
            var row = db.Employees.Where(model=>model.EmployeeId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Employee e) 
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
                var row = db.Employees.Where(model => model.EmployeeId == id).FirstOrDefault();
                if(row != null)
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
            var row = db.Employees.Where(model => model.EmployeeId == id).FirstOrDefault();
            return View(row);
        }
    }
}