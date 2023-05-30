using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class FlataRate : Placanje
    {
        public virtual IList<StatickaAdresa> StatickeAdrese { get; set; }
        public FlataRate()
        {
            StatickeAdrese = new List<StatickaAdresa>();
        }
    }
}
