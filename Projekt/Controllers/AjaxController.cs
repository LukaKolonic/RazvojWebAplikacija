using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult GetAutocomplete(string term)
        {
            var podaci = Repo.GetKupci()
                .Where(k => k.Ime.ToLower().Contains(term) || k.Prezime.ToLower().Contains(term))
                .Select(k => new
                {
                    label=k.ToString(),
                    value=k.IDKupac

                });

            return Json(podaci, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRacuni(int id)
        {
            return Json(Repo.GetRacuni(id), JsonRequestBehavior.AllowGet);
        }
    }
}