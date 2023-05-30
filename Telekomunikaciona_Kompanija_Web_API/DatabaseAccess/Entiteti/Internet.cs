using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekomunikaciona_Kompanija_NHibernate.Entiteti
{
    public class Internet : Usluga
    {
        public virtual string TipInterneta { get; set; }
        public virtual bool FlagPrepaid { get; set; }

        public virtual DateTime DatumPoslednjeUplate { get; set; }
        public virtual int StanjeRacuna { get; set; }
        public virtual Placanje Placanje { get; set; }
    }
}
