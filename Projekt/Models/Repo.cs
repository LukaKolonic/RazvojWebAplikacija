using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Repo
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IEnumerable<Kupac> GetKupci()
        {
            
            ds = SqlHelper.ExecuteDataset(cs, "GetKupci");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKupacFromDataRow(row);

            }
            
        }

        public static Kupac GetKupacById(int IDKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKupacById", IDKupac).Tables[0].Rows[0];
            return GetKupacFromDataRow(row);
        }

        private static Kupac GetKupacFromDataRow(DataRow row)
        {
            Kupac k = new Kupac();

            k.IDKupac = (int)row["IDKupac"];
            k.Ime = row["ime"].ToString();
            k.Prezime = row["prezime"].ToString();
            k.Email = row["email"].ToString();
            k.Telefon = row["telefon"].ToString();
            k.GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1;

            return k;
        }

        public static Proizvod GetProizvod(int IDProizvod)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvod", IDProizvod).Tables[0].Rows[0];
            return GetProizvodFromDataRow(row);
        }


        public int UpdateKupac(Kupac k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", k.IDKupac, k.Ime, k.Prezime, k.Email, k.Telefon, k.GradID);
        }

        public static Grad GetGrad(int gradID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetGrad", gradID).Tables[0].Rows[0];
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                Naziv = row["Naziv"].ToString()
            };
        }

       

        public static IEnumerable<Racun> GetRacuni(int kupacID)
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetRacuni",kupacID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetRacunFromDataRow(row);

            }

        }

        private static Racun GetRacunFromDataRow(DataRow row)
        {
            Racun r = new Racun();

            r.IDRacun = (int)row["IDRacun"];
            r.DatumIzdavanja = DateTime.Parse(row["DatumIzdavanja"].ToString());
            r.BrojRacuna = row["BrojRacuna"].ToString();
           

            return r;
        }

        public static IEnumerable<Stavka> GetStavke(int id)
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetStavke", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetStavkaFromDataRow(row);

            }

        }

        private static Stavka GetStavkaFromDataRow(DataRow row)
        {
            Stavka s = new Stavka();

            s.IDStavka = (int)row["IDStavka"];
            s.RacunID = (int)row["RacunID"];
            //s.Kolicina = (short)row["Kolicina"];
            s.ProizvodID = (int)row["ProizvodID"];
            //s.CijenaPoKomadu = (decimal)row["CijenaPoKomadu"];
            //s.PopustUPostocima = (decimal)row["PopustUPostocima"];
            //s.UkupnaCijena = (decimal)row["UkupnaCijena"];
            s.Proizvod = GetProizvod((int)row["ProizvodID"]);
            s.KrKartica= GetKreditnaKarticaFromDataRow(row);
            s.Komercijalist= GetKomercijalistFromDataRow(row);


            return s;
        }

        private static Komercijalist GetKomercijalistFromDataRow(DataRow row)
        {
            Komercijalist kom = new Komercijalist();

            kom.IDKomercijalist = (int)row["IDKomercijalist"];
            kom.Ime = (string)row["Ime"];
            kom.Prezime = (string)row["Prezime"];
            kom.StalniZaposlenik  = (bool)row["StalniZaposlenik"];


            return kom;
        }

        private static KreditnaKartica GetKreditnaKarticaFromDataRow(DataRow row)
        {
            KreditnaKartica kr = new KreditnaKartica();

            kr.IDKreditnaKartica = row["IDKreditnaKartica"] != DBNull.Value ? (int)row["IDKreditnaKartica"] : default;
            kr.Tip = row["Tip"].ToString();
            kr.Broj = row["Broj"].ToString();
            kr.IstekMjesec = row["IstekMjesec"].ToString();
            kr.IstekGodina = row["IstekGodina"].ToString();

            return kr;
        }

        private static Kategorija GetKategorijaFromDataRow(DataRow row)
        {
            Kategorija k = new Kategorija();

            k.IDKategorija = (int)row["IDKategorija"];
            k.NazivKat = row["Naziv"].ToString();

            return k;
        }

        private static Potkategorija GetPotkategorijaFromDataRow(DataRow row)
        {
            Potkategorija p = new Potkategorija();


            p.IDPotkategorija = (int)row["IDPotkategorija"];
            p.KategorijaID = (int)row["KategorijaID"];
            p.NazivPotk = row["Naziv"].ToString();
            p.Kategorija = GetKategorija((int)row["KategorijaID"]);

            return p;
        }

        private static Proizvod GetProizvodFromDataRow(DataRow row)
        {
            Proizvod p = new Proizvod();

            p.IDProizvod = (int)row["IDProizvod"];
            p.Naziv = row["Naziv"].ToString();
            p.BrojProizvoda = row["BrojProizvoda"].ToString();
            p.Boja = row["Boja"] != DBNull.Value ? row["Boja"].ToString() : default;
            p.MinimalnaKolicinaNaSkladistu = (short)row["MinimalnaKolicinaNaSkladistu"];
            p.CijenaBezPdv = (decimal)row["CijenaBezPDV"];
            p.PotkategorijaID = row["PotkategorijaID"] != DBNull.Value ? (int)row["PotkategorijaID"] : default;
            p.Potkategorija = row["PotkategorijaID"] != DBNull.Value ? GetPotkategorija((int)row["PotkategorijaID"]) : default;
                
            return p;
        }

        //proizvod
        public static IEnumerable<Proizvod> GetProizvodi()
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetProizvodFromDataRow(row);

            }

        }

        public static int UpdateProizvod(Proizvod p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPdv, p.PotkategorijaID);
        }


        public static int DeleteProizvod(int IDProizvod) => SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", IDProizvod);

        internal static void CreateProizvod(Proizvod p) => SqlHelper.ExecuteNonQuery(cs, "CreateProizvod", p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPdv, p.PotkategorijaID);

        //kategorija

        public static IEnumerable<Kategorija> GetKategorije()
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetKategorije");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKategorijaFromDataRow(row);

            }

        }

        public static Kategorija GetKategorija(int IDKategorija)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKategorija", IDKategorija).Tables[0].Rows[0];
            return GetKategorijaFromDataRow(row);
        }


        public static int UpdateKategorija(Kategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKategorija", k.IDKategorija, k.NazivKat);
        }

        public static int DeleteKategorija(int IDKategorija) => SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", IDKategorija);

        internal static void CreateKategorija(Kategorija k) => SqlHelper.ExecuteNonQuery(cs, "CreateKategorija", k.NazivKat);

        //potkategorija

        public static IEnumerable<Potkategorija> GetPotkategorije()
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorije");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetPotkategorijaFromDataRow(row);

            }

        }

        public static Potkategorija GetPotkategorija(int IDPotkategorija)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotkategorija", IDPotkategorija).Tables[0].Rows[0];
            return GetPotkategorijaFromDataRow(row);
        }

        public static int UpdatePotkategorija(Potkategorija pk)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija", pk.IDPotkategorija, pk.NazivPotk, pk.KategorijaID);
        }

        public static int DeletePotkategorija(int IDPotkategorija) => SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", IDPotkategorija);

        internal static void CreatePotkategorija(Potkategorija pk) => SqlHelper.ExecuteNonQuery(cs, "CreatePotkategorija", pk.NazivPotk, pk.KategorijaID);


    }
}