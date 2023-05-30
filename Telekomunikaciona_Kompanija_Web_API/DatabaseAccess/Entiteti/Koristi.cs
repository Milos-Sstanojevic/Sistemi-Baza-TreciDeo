using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Koristi
    {
        public virtual int Id { get; set; }
        public virtual Korisnik JMBG_Korisnika { get; set; }
        public virtual Usluga ID_Usluge { get; set; }
    }
}
