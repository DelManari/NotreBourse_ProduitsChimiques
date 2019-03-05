using loginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(loginTest.Models.test test)
        {
            using (ProductChimiqueEntities db = new ProductChimiqueEntities())
            {
                var userDetails = db.tests.Where(x => x.Username == test.Username && x.Password == test.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    test.LoginErrorMessage = "Wrong username or password !";
                    return View("Index",test);
                }
                else
                {
                    Session["UserID"] = userDetails.id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}