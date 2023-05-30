using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class BrojTelefonaMapiranja : ClassMap<BrojTelefona>
    {
        public BrojTelefonaMapiranja()
        {
            Table("BROJ_TELEFONA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Broj, "BROJ");
            Map(x => x.Potroseni_minuti, "POTROSENI_MINUTI");

            References(x => x.PripadaTelefoniji).Column("TELEFONIJA").LazyLoad();
        }
    }
}
