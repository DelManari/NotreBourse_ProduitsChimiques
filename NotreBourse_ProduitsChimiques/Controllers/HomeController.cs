using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class HomeController : Controller
    {
      //  [Authorize]
        // GET: HomeAdmin
        public ActionResult HomeAdmin()
        {
            return View();
        }
        // GET: HomeUtilisateur
        public ActionResult HomeUtilisateur()
        {
            return View();
        }
    }
}