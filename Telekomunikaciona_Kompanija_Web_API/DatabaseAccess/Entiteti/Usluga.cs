using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Usluga
    {
        public virtual int Id { get; set; }
        public virtual string Tip_usluge { get; set; }
        public virtual IList<Koristi> Uslugu_koristi { get; set; }

        public Usluga()
        {
            Uslugu_koristi = new List<Koristi>();
        }
    }
}
