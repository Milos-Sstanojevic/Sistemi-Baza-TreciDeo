using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Korisnik
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Broj { get; set; }
        public virtual string Grad { get; set; }
        public virtual string Tip_korisnika { get; set; }
        public virtual IList<Telefon> Telefoni_korinika { get; set; }
        public virtual Komunikacioni_cvor Kom_cvor { get; set; }

        public virtual IList<Koristi> Korisnik_koristi { get; set; }

        public Korisnik()
        {
            Korisnik_koristi=new List<Koristi>();
            Telefoni_korinika = new List<Telefon>();
        }
    }

    public class Fizicka_lica : Korisnik
    {

    }
}
