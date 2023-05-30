using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class GlavnaStanicaMapiranje : SubclassMap<Glavna_stanica>
    {
        public GlavnaStanicaMapiranje()
        {
            Table("GLAVNA_STANICA");

            KeyColumn("SERIJSKI_BROJ");

            Map(x => x.Flag_Hub, "FLAG_HUB");
            Map(x => x.Region, "REGION");

            References(x => x.Glavna_stanica_hub).Column("HUB_GLAVNA_STANICA").LazyLoad();

            HasMany(x => x.Hub_glavna_stanica).KeyColumn("HUB_GLAVNA_STANICA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Komunikacioni_cvor).KeyColumn("GLAVNA_STANICA_KOM_CVORA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
