using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        // GET: Bills
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stavke(int id)
        {
            var stavke = Repo.GetStavke(id);
            return View(stavke);
        }


    }
}