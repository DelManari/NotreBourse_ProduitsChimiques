using NotreBourse_ProduitsChimiques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class AnnoncesController : Controller
    {
        // GET: Annonces
        public ActionResult Index()
        {
            using (ProductChimiqueEntities3 dbModel = new ProductChimiqueEntities3())
            {
                var annonce = dbModel.Annonces;
                return View(annonce.ToList());
            }
        }
        // GET: AjoutAnnonce
        public ActionResult AjoutAnnonce(int id = 0)
        {
            Annonce AnnonceModel = new Annonce();
            ProductChimiqueEntities2 dbModel = new ProductChimiqueEntities2();
            var GetProductsList = dbModel.Produits.ToList();
            SelectList list = new SelectList(GetProductsList, "Id", "Label");
            ViewData["Products"] = list;
            return View(AnnonceModel);
        }
        // GET: ModificationAnnonce
        public ActionResult ModificationAnnonce()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(Annonce AnnonceModel)
        {
            using (ProductChimiqueEntities3 dbModel = new ProductChimiqueEntities3())
            {
                try
                {
                    AnnonceModel.IdAuteur = Int32.Parse(Session["UserID"].ToString());
                    AnnonceModel.DatePublicationAnnonce = DateTime.Now;
                    AnnonceModel.IdProduit = Int32.Parse(Request.Form["ProductList_0"].ToString());

                    dbModel.Annonces.Add(AnnonceModel);
                    dbModel.SaveChanges();
                }
                catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }
            }
            ModelState.Clear();
            TempData["SuccessMessage"] = "Registation Sucessful";
            return RedirectToAction("AjoutAnnonce", new Annonce());
        }
        public ActionResult edit(int idx)
        {

            using (ProductChimiqueEntities3 dbModel = new ProductChimiqueEntities3())
            {
                Annonce record =
            (
             from x in dbModel.Annonces
             where x.Id == idx
             select x
             ).Single();


                ProductChimiqueEntities2 dbModeld = new ProductChimiqueEntities2();
                var GetProductsList = dbModeld.Produits.ToList();
                SelectList list = new SelectList(GetProductsList, "Id", "Label");
                ViewData["Products"] = list;

                //delete old product
                Annonce dept = dbModel.Annonces.Single(x => x.Id == idx);
                System.Diagnostics.Debug.WriteLine(dept.Id);

                dbModel.Annonces.Remove(dept);
                dbModel.SaveChanges();

                //product deleted
                return View("ModificationAnnonce", record);
            }
        }
        [HttpPost]
        public ActionResult ModificationAnnonce(Annonce annonceModel)
        {
            using (ProductChimiqueEntities3 dbModel = new ProductChimiqueEntities3())
            {


                annonceModel.IdAuteur = Int32.Parse(Session["UserID"].ToString());
                annonceModel.DatePublicationAnnonce = DateTime.Now;
                annonceModel.IdProduit = Int32.Parse(Request.Form["ProductList_0"].ToString());

                dbModel.Annonces.Add(annonceModel);
                dbModel.SaveChanges();
                ModelState.Clear();
                TempData["SuccessMessage"] = "Update Sucessful";
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteAnnonce(int idx)
        {
            ProductChimiqueEntities3 sqlObj = new ProductChimiqueEntities3();

            Annonce dept = sqlObj.Annonces.Single(x => x.Id == idx);

            sqlObj.Annonces.Remove(dept);

            sqlObj.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}