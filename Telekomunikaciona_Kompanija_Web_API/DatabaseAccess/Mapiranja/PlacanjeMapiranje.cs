using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class PlacanjeMapiranje : ClassMap<Placanje>
    {
        public PlacanjeMapiranje()
        {
            Table("PLACANJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.TipPlacanja, "TIP_PLACANJA");

            //HasMany(x=>x.Interneti).KeyColumn("PLACANJE_INTERNETA").LazyLoad().Inverse().Cascade.All();
        }
    }
}
