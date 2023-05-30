using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class UslugaMapiranje: ClassMap<Usluga>
    {
        public UslugaMapiranje()
        {
            Table("USLUGA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Tip_usluge, "TIP_USLUGE");

            HasMany(x => x.Uslugu_koristi).KeyColumn("ID_USLUGE").LazyLoad().Cascade.All().Inverse();
        }
    }
}
 