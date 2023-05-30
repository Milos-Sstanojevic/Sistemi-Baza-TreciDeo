using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Uredjaj
    {
        public virtual string Proizvodjac { get;set; }
        public virtual DateTime Datum_pocetka_upotrebe { get; set; }
        public virtual string Razlog_poslednjeg_servisa { get; set; }
        public virtual string Tip_uredjaja { get; set; }
        public virtual Int64 Serijski_broj { get; set; }
    }
    
}
