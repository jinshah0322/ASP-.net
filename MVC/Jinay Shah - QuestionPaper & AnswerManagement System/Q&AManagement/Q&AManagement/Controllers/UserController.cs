using Q_AManagement.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Q_AManagement.Helpers;

namespace Q_AManagement.Controllers
{
    //This is User Controller
    public class UserController : Controller
    {
        QandAEntities db = new QandAEntities();
        PasswordEncryptionDecryption obj = new PasswordEncryptionDecryption();

        //This function is used to display the register view to the user
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

        //This function is used when user posts its data into form and click submit
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

        //This function is used to display the login view to the user
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

        //This function is used when user posts its data into login form and click submit
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

        //This function is called when user clicks on logout button
        public ActionResult Logout()
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login","User");
        }
    }
}
