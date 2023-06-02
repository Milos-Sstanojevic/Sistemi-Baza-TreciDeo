using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KomunikacioniCvorView:UredjajView
    {
        public string Opis { get; set; }
        public int Broj_lokacije { get; set; }
        public string Adresa { get; set; }
        public GlavnaStanicaView Glavna_stanica_kom_cvora { get; set; }
        public IList<KorisnikView> Korisnik { get; set; }

        public KomunikacioniCvorView()
        {
            Korisnik = new List<KorisnikView>();
        }

        public KomunikacioniCvorView(Komunikacioni_cvor kc) : base(kc)
        {
            Opis = kc.Opis;
            Broj_lokacije = kc.Broj_lokacije;
            Adresa = kc.Adresa;
        }

    }
}
