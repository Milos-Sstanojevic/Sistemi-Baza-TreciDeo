using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class FlatRate : Placanje
    {
        public virtual IList<StatickaAdresa> StatickeAdrese { get; set; }
        public FlatRate()
        {
            StatickeAdrese = new List<StatickaAdresa>();
        }
    }
}
