using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class BrojTelefona
    {
        public virtual int Id { get; set; }
        public virtual int Broj { get; set; }
        public virtual int Potroseni_minuti { get; set; }
        public virtual Telefonija PripadaTelefoniji { get; set; }
    }
}
