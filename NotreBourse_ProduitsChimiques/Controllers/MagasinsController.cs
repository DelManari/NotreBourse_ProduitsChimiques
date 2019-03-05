using NotreBourse_ProduitsChimiques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class MagasinsController : Controller
    {
        // GET: Magasins
        public ActionResult Index()
        {
            using (ProductChimiqueEntities5 dbModel = new ProductChimiqueEntities5())
            {
                var magasins = dbModel.Magasins;
                return View(magasins.ToList());
            }
        }


        public ActionResult AjoutMagasin(int id = 0)
        {
            Magasin MagasinModel = new Magasin();
            ProductChimiqueEntities1 dbModel = new ProductChimiqueEntities1();
            var GetUsersList = dbModel.Users.ToList();
            SelectList list = new SelectList(GetUsersList, "IdUser", "Nom");
            ViewData["Users"] = list;
            return View(MagasinModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Magasin MagasinModel)
        {
            using (ProductChimiqueEntities5 dbModel = new ProductChimiqueEntities5())
            {
                try
                {
                    MagasinModel.Responsable = Int32.Parse(Request.Form["UsersList_0"].ToString());
                    dbModel.Magasins.Add(MagasinModel);
                    dbModel.SaveChanges();
                }
                catch (Exception e) { }
            }
            ModelState.Clear();
            TempData["SuccessMessage"] = "Registation Sucessful";
            return RedirectToAction("AjoutMagasin", new Magasin());
        }

        public ActionResult edit(int idx)
        {

            using (ProductChimiqueEntities5 dbModel = new ProductChimiqueEntities5())
            {
                Magasin record =
            (
             from x in dbModel.Magasins
             where x.Id == idx
             select x
             ).Single();


                ProductChimiqueEntities1 dbModeld = new ProductChimiqueEntities1();
                var GetUsersList = dbModeld.Users.ToList();
                SelectList list = new SelectList(GetUsersList, "IdUser", "Nom");
                ViewData["Users"] = list;


                //delete old product
                Magasin dept = dbModel.Magasins.Single(x => x.Id == idx);
                System.Diagnostics.Debug.WriteLine(dept.Id);

                dbModel.Magasins.Remove(dept);
                dbModel.SaveChanges();

                //product deleted
                return View("ModificationMagasins", record);
            }
        }
        [HttpPost]
        public ActionResult ModificationMagasins(Magasin magasinModel)
        {
            using (ProductChimiqueEntities5 dbModel = new ProductChimiqueEntities5())
            {



                magasinModel.Responsable = Int32.Parse(Request.Form["UsersList_0"].ToString());

                dbModel.Magasins.Add(magasinModel);
                dbModel.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Update Sucessful";
                return RedirectToAction("Index");
            }
        }


        // GET: ModificationProduit
        public ActionResult ModificationMagasins()
        {
            return View();
        }
        public ActionResult DeleteProduct(int idx)
        {
            ProductChimiqueEntities5 sqlObj = new ProductChimiqueEntities5();

            Magasin dept = sqlObj.Magasins.Single(x => x.Id == idx);

            sqlObj.Magasins.Remove(dept);

            sqlObj.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}