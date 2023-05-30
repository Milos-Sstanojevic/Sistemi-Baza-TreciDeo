using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Komunikacioni_cvor : Uredjaj
    {
        public virtual string Opis { get; set; }
        public virtual int Broj_lokacije { get; set; }
        public virtual string Adresa { get; set; }
        public virtual Glavna_stanica Glavna_stanica_kom_cvora {get;set; }
        public virtual  IList<Korisnik> Korisnik { get; set; }
    
        public Komunikacioni_cvor()
        {
            Korisnik=new List<Korisnik>();
        }
    }
}
