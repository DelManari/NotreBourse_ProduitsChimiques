using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotreBourse_ProduitsChimiques.Models;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AjoutUsers(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (ProductChimiqueEntities1 dbModel = new ProductChimiqueEntities1())
            {
                if (dbModel.Users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Produict Already Existed";
                    return View("AjoutProduit", userModel);

                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registation Sucessful";
            return View("AjoutUsers", new User());
        }
    }
}