using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class DodatniPaketKanala
    {
        public virtual int Id { get; set; }
        public virtual string DodatniPaket { get; set; }
        public virtual Televizija Televizija { get; set; }
    }
}
