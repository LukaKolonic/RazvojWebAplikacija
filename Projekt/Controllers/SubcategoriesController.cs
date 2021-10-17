using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{

    [Authorize]
    public class SubcategoriesController : Controller
    {
        // GET: Subcategories
        public ActionResult Index()
        {
            return View(Repo.GetPotkategorije());
        }

        [HttpGet]
        public ActionResult AddSubcategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubcategory(Potkategorija pk)
        {
            if (ModelState.IsValid)
            {
                Repo.CreatePotkategorija(pk);
                return View("SuccessSubcategories", pk);
            }
            else
            {
                return View(pk);
            }
        }

        [HttpGet]
        public ActionResult EditSubcategory(int id)
        {
            return View(Repo.GetPotkategorija(id));
        }

        [HttpPost]
        public ActionResult EditSubcategory(Potkategorija pk)
        {

            if (ModelState.IsValid)
            {
                Repo.UpdatePotkategorija(pk);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pk);
            }
        }

        public ActionResult DeleteSubcategory(int id)
        {

            Repo.DeletePotkategorija(id);
            return RedirectToAction("Index");

        }
    }
}