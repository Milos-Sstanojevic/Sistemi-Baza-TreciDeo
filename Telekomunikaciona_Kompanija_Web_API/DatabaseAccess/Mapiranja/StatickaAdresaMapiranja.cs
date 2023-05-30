using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class StatickaAdresaMapiranja : ClassMap<StatickaAdresa>
    {
        public StatickaAdresaMapiranja()
        {
            Table("STATICKA_ADRESA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Staticka_Adresa, "STATICKA_ADRESA");

            References(x=>x.FlatRate).Column("FLAT_RATE").LazyLoad();
        }
    }
}
