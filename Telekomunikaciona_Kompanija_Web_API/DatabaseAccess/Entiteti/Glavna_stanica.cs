using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Glavna_stanica:Uredjaj
    {
        public virtual bool Flag_Hub { get;set; }
        public virtual string Region { get; set; }
        public virtual Glavna_stanica Glavna_stanica_hub { get; set; }
        public virtual IList<Glavna_stanica> Hub_glavna_stanica { get; set; }
        public virtual IList<Komunikacioni_cvor> Komunikacioni_cvor { get; set; }
        public Glavna_stanica()
        {
            Flag_Hub = false;
            Hub_glavna_stanica = new List<Glavna_stanica>();
            Komunikacioni_cvor = new List<Komunikacioni_cvor>();
        }
    }
}
