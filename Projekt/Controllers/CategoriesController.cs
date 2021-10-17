using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        [Authorize]
        public ActionResult Index()
        {
            return View(Repo.GetKategorije());
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Kategorija k)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateKategorija(k);
                return View("SuccessCategory", k);
            }
            else
            {
                return View(k);
            }
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            return View(Repo.GetKategorija(id));
        }

        [HttpPost]
        public ActionResult EditCategory(Kategorija k)
        {

            if (ModelState.IsValid)
            {
                Repo.UpdateKategorija(k);
                return RedirectToAction("Index");
            } 
            else
            {
                return View(k);
            }
        }

        public ActionResult DeleteCategory(int id)
        {

            Repo.DeleteKategorija(id);
            return RedirectToAction("Index");

        }
    }
}