using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KorisnikView
    {
        public  string JMBG { get; set; }
        public  string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Broj { get; set; }
        public string Grad { get; set; }
        public string Tip_korisnika { get; set; }
        public   IList<TelefonView> Telefoni_korinika { get; set; }
        public KomunikacioniCvorView Kom_cvor { get; set; }

        public IList<KoristiView> Korisnik_koristi { get; set; }

        public KorisnikView()
        {
            Korisnik_koristi = new List<KoristiView>();
            Telefoni_korinika = new List<TelefonView>();
        }

        public KorisnikView(Korisnik k)
        {
            JMBG = k.JMBG;
            Ime = k.Ime;
            Prezime = k.Prezime;
            Adresa = k.Adresa;
            Broj = k.Broj;  
            Grad = k.Grad;
            Tip_korisnika= k.Tip_korisnika;
        }
    }
}
