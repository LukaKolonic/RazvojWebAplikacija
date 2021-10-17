using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Kategorija
    {
        [Required(ErrorMessage = "IDKategorija is required")]
        public int IDKategorija { get; set; }
        [Required(ErrorMessage = "Naziv is required")]
        [Display(Name = "Naziv")]
        public string NazivKat { get; set; }
    }
}