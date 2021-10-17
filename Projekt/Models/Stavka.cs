using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Stavka
    {
        public int IDStavka { get; set; }
        public int RacunID { get; set; }
        //public short Kolicina { get; set; }
        public int ProizvodID { get; set; }
        //public decimal CijenaPoKomadu { get; set; }
        //public decimal PopustUPostocima { get; set; }
        //public decimal UkupnaCijena { get; set; }

        public Proizvod Proizvod { get; set; }
        //public Potkategorija Potkategorija { get; set; }
        //public Kategorija Kategorija { get; set; }
        public KreditnaKartica KrKartica { get; set; }
        public Komercijalist Komercijalist { get; set; }
    }
}