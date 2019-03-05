using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NotreBourse_ProduitsChimiques
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            //Startup Page
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Accueil",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            // /Home/HomeAdmin
            routes.MapRoute(
                name: "Home0",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "HomeAdmin",
                    id = UrlParameter.Optional
                }
            );
            // /Home/HomeUtilisateur
            routes.MapRoute(
                name: "Home1",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "HomeUtilisateur",
                    id = UrlParameter.Optional
                }
            );
            // /Produits
            routes.MapRoute(
                name: "Produits0",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Produits",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            // /Produits/AjoutProduit
            routes.MapRoute(
                name: "Produits1",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Produits",
                    action = "AjoutProduit",
                    id = UrlParameter.Optional
                }
            );
            // /Produits/ModificationProduit
            routes.MapRoute(
                name: "Produits2",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Produits",
                    action = "ModificationProduit",
                    id = UrlParameter.Optional
                }
            );
            // /Annonces
            routes.MapRoute(
                name: "Annonces0",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Annonces",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            // /Annonces/AjoutAnnonce
            routes.MapRoute(
                name: "Annonces1",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Annonces",
                    action = "AjoutAnnonce",
                    id = UrlParameter.Optional
                }
            );
            // /Annonces/ModificationAnnonce
            routes.MapRoute(
                name: "Annonces2",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Annonces",
                    action = "ModificationAnnonce",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
