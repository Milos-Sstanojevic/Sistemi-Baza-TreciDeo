using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PravnoLiceView:KorisnikView
    {
        public string Ime_kontakt_osobe { get; set; }
        public long Broj_faksa { get; set; }
        public long Poreski_identifikacioni_broj { get; set; }

        public PravnoLiceView() { }

        public PravnoLiceView(Pravna_lica pl) : base(pl)
        {
            Ime_kontakt_osobe = pl.Ime_kontakt_osobe;
            Broj_faksa = pl.Broj_faksa;
            Poreski_identifikacioni_broj = pl.Poreski_identifikacioni_broj;
        }
    }
}
