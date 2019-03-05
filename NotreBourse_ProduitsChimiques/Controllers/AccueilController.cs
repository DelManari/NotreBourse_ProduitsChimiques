using NotreBourse_ProduitsChimiques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(NotreBourse_ProduitsChimiques.Models.User user)
        {
            using (ProductChimiqueEntities1 db = new ProductChimiqueEntities1())
            {
                var userDetails = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.LoginErrorMessage = "Wrong username or password !";
                    return View("Index", user);
                }
                else
                {
                    Session["UserID"] = userDetails.IdUser;
                    Session["Username"] = userDetails.Username;
                    Session["Type"] = userDetails.Type;
                    if(userDetails.Type =="admin")
                    return RedirectToAction("HomeAdmin", "Home");
                    else 
                        return RedirectToAction("HomeUtilisateur", "Home");

                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Accueil");
        }
    }
}