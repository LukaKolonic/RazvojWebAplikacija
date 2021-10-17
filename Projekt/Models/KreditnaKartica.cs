using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class KreditnaKartica
    {
        public int IDKreditnaKartica { get; set; }
        public string Tip { get; set; }
        public string Broj { get; set; }
        public string IstekMjesec { get; set; }
        public string  IstekGodina { get; set; }
    }
}