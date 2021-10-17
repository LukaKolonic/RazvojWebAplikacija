using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [Authorize]
        public ActionResult Index()
        {
            return View(Repo.GetProizvodi());
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Proizvod p)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateProizvod(p);
                return View("Success", p);
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {  
            return View(Repo.GetProizvod(id));
        }

        [HttpPost]
        public ActionResult EditProduct(Proizvod p)
        {

            if (ModelState.IsValid)
            {
                Repo.UpdateProizvod(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult DeleteProduct(int id)
        {

            Repo.DeleteProizvod(id);
            return RedirectToAction("Index");

        }
    }
}