using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class FlatRateMapiranja : SubclassMap<FlatRate>
    {
        public FlatRateMapiranja()
        {
            Table("FLAT_RATE");

            KeyColumn("ID_PLACANJA");

            HasMany(x=>x.StatickeAdrese).KeyColumn("FLAT_RATE").LazyLoad().Inverse().Cascade.All();
        }
    }
}
