using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Potkategorija
    {
        [Required(ErrorMessage = "IDPotkategorija is required")]
        public int IDPotkategorija { get; set; }
        [Required(ErrorMessage = "KategorijaID is required")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Value is out of range")]
        public int KategorijaID { get; set; }
        [Required(ErrorMessage = "Naziv is required")]
        [Display(Name = "Naziv")]
        public string NazivPotk { get; set; }

        public Kategorija Kategorija { get; set; }
    }
}