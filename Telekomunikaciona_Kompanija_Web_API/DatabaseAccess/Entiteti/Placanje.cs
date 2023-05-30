using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Placanje
    {
        public virtual int Id { get; set; }
        public virtual string TipPlacanja { get; set; }
    }
}
