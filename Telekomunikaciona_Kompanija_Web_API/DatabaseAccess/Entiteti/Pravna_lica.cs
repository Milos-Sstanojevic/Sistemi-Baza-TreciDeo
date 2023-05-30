using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Pravna_lica:Korisnik
    {
        public virtual string Ime_kontakt_osobe { get; set; }
        public virtual long Broj_faksa { get; set; }
        public virtual long Poreski_identifikacioni_broj { get; set; }
    }
}
