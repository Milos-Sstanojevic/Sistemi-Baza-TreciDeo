using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Telefonija : Usluga
    {
        public virtual IList<BrojTelefona> Brojevi_Telefona { get; set; }

        public Telefonija()
        {
            Brojevi_Telefona = new List<BrojTelefona>();
        }
    }
}
