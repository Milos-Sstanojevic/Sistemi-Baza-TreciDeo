using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class UredjajView
    {
        public  string Proizvodjac { get; set; }
        public  DateTime Datum_pocetka_upotrebe { get; set; }
        public  string Razlog_poslednjeg_servisa { get; set; }
        public string Tip_uredjaja { get; set; }
        public Int64 Serijski_broj { get; set; }

        public UredjajView()
        {

        }

        public UredjajView(Uredjaj u)
        {
            Proizvodjac = u.Proizvodjac;
            Datum_pocetka_upotrebe = u.Datum_pocetka_upotrebe;
            Razlog_poslednjeg_servisa = u.Razlog_poslednjeg_servisa;
            Tip_uredjaja=u.Tip_uredjaja;
            Serijski_broj=u.Serijski_broj;
        }
    }
}
