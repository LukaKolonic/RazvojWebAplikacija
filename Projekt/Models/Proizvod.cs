using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Proizvod
    {
        [Required(ErrorMessage = "IDProizvod is required")]
        public int IDProizvod { get; set; }
        [Required(ErrorMessage = "Naziv is required")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Broj proizvoda is required")]
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        [Display(Name = "Količina")]
        [Required(ErrorMessage = "Minimalna kolicina is required")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Value is out of range")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        [Required(ErrorMessage = "Cijena bez PDV is required")]
        [Range(0, Double.MaxValue, ErrorMessage = "Value is out of range")]
        public decimal CijenaBezPdv { get; set; }
        public int PotkategorijaID { get; set; }

        public Potkategorija Potkategorija { get; set; }
    }
}