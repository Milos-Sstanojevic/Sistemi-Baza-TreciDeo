using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Telefon
    {
        public virtual int Id { get; set; }
        public virtual Korisnik JMBG_korisnika { get; set; }
        public virtual long telefon { get; set; }
    }
}
