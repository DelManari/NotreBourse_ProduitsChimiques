using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotreBourse_ProduitsChimiques.Models;

namespace NotreBourse_ProduitsChimiques.Controllers
{
    public class ProduitsController : Controller
    {
        // GET: Produits
        public ActionResult Index()
        {
            using (ProductChimiqueEntities2 dbModel = new ProductChimiqueEntities2())
            {
                var produits = dbModel.Produits;
                return View(produits.ToList());
            }
        }
        // GET: AjoutProduit
        public ActionResult AjoutProduit(int id = 0)
        {
            Produit produitModel = new Produit();
            return View(produitModel);
        }

        // GET: ModificationProduit
        public ActionResult edit(int idx)
        {

            using (ProductChimiqueEntities2 dbModel = new ProductChimiqueEntities2())
            {
                Produit record =
            (
             from x in dbModel.Produits
             where x.Id == idx
             select x
             ).Single();

                //delete old product
                Produit dept = dbModel.Produits.Single(x => x.Id == idx);
                dbModel.Produits.Remove(dept);

                //product deleted
                return View("ModifyProduct", record);
            }
        }
        [HttpPost]
        public ActionResult ModifyProduct(Produit produitModel)
        {
            using (ProductChimiqueEntities2 dbModel = new ProductChimiqueEntities2())
            {
                dbModel.Produits.Add(produitModel);
                dbModel.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Update Sucessful";
                return RedirectToAction("Index");
            }   
        }


        [HttpPost]
        public ActionResult AddOrEdit(Produit produitModel)
        {
            using (ProductChimiqueEntities2 dbModel = new ProductChimiqueEntities2())
            {
                if(dbModel.Produits.Any(x =>x.Label == produitModel.Label) )
                {
                    ViewBag.DuplicateMessage = "Produict Already Existed";
                    return View("AjoutProduit",produitModel);

                }
                
                dbModel.Produits.Add(produitModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registation Sucessful";
            return View("AjoutProduit", new Produit());
        }
         public ActionResult DeleteProduct(int idx)
        {
            ProductChimiqueEntities2 sqlObj = new ProductChimiqueEntities2();

            Produit dept = sqlObj.Produits.Single(x => x.Id == idx);

            sqlObj.Produits.Remove(dept);

            sqlObj.SaveChanges();
            return RedirectToAction("Index");

            
        }
    }
}