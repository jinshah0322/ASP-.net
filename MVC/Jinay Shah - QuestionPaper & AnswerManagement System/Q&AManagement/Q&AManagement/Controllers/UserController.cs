using Q_AManagement.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Q_AManagement.Controllers
{
    public class UserController : Controller
    {
        QandAEntities db = new QandAEntities();

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
                    return RedirectToAction("", "");
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
                        string encryptedPassword = EncryptString(u.Password);
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
                    return RedirectToAction("", "");
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
                string decryptedPassword = DecryptString(user.Password);

                if (decryptedPassword == u.Password)
                {
                    Session["UserId"] = user.UserID;
                    Session["Role"] = user.Role;
                    if(user.Role == "Admin")
                    {
                        return RedirectToAction("", "");
                    }
                    else if(user.Role == "Student")
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else if(user.Role == "Teacher")
                    {
                        return RedirectToAction("", "");
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

        private string EncryptString(string plainText)
        {
            const string EncryptionKey = "qWE7&5pZ@2#9Df!1gH*3sKl$8oP5mN^0";
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            const string EncryptionKey = "qWE7&5pZ@2#9Df!1gH*3sKl$8oP5mN^0";
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
