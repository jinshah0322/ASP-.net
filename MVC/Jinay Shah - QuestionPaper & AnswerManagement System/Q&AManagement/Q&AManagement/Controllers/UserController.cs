using Q_AManagement.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Q_AManagement.Helpers;

namespace Q_AManagement.Controllers
{
    public class UserController : Controller
    {
        QandAEntities db = new QandAEntities();
        PasswordEncryptionDecryption obj = new PasswordEncryptionDecryption();
        public ActionResult Register()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }
            else
            {
                var userID = Convert.ToInt32(Session["UserId"]); ;
                var user = db.Users.Where(model => model.UserID == userID).FirstOrDefault();
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (user.Role == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                
                    if (db.Users.Any(model => model.Email == u.Email))
                    {
                        TempData["RegisterMessage"] = "Email already exists!!";
                    }
                    else
                    {
                        string encryptedPassword = obj.EncryptString(u.Password);
                        u.Password = encryptedPassword;

                        db.Users.Add(u);
                        db.SaveChanges();
                        TempData["RegisterMessage"] = "User Created Successfully!!";
                    }
                    return RedirectToAction("Login");
                }
            return View();
        }

        public ActionResult Login()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }
            else
            {
                var userID = Convert.ToInt32(Session["UserId"]); ;
                var user = db.Users.Where(model => model.UserID == userID).FirstOrDefault();
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (user.Role == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            var user = db.Users.FirstOrDefault(model => model.Email == u.Email);
            if (user != null)
            {
                string decryptedPassword = obj.DecryptString(user.Password);

                if (decryptedPassword == u.Password)
                {
                    Session["UserId"] = user.UserID;
                    Session["Role"] = user.Role;
                    if(user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if(user.Role == "Student")
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else if(user.Role == "Teacher")
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                }
            }
            TempData["LoginErrorMessage"] = "Invalid email or password";
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login","User");
        }
    }
}
