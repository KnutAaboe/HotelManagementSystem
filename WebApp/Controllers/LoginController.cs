using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(guest account)
        {
            if(ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.firstname + " " + account.lastname + " successfully registered."; 
            }
            return View();
        }

        //Login 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(guest user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.username == user.username && u.pass == user.pass);
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}