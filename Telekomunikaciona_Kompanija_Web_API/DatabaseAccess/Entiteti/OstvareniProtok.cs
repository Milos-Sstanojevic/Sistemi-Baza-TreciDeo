using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class OstvareniProtok: Placanje
    {
        public virtual int Protok { get; set; }
    }
}
