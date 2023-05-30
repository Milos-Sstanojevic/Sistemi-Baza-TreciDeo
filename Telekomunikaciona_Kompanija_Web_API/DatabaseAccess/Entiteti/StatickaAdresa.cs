using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class StatickaAdresa
    {
        public virtual int Id { get; set; }
        public virtual string Staticka_Adresa { get; set; }
        public virtual FlatRate FlatRate { get; set; }
    }
}
