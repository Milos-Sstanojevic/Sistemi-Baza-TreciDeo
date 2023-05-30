using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Televizija : Usluga
    {
        public virtual string Paket { get; set; }
        public virtual IList<DodatniPaketKanala> DodatniPaketiKanala { get; set; }
        public Televizija()
        {
            DodatniPaketiKanala = new List<DodatniPaketKanala>();
        }
    }
}
