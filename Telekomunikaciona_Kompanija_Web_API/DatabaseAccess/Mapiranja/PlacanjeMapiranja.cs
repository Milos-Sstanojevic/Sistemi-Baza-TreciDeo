using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class PlacanjeMapiranja : ClassMap<Placanje>
    {
        public PlacanjeMapiranja()
        {
            Table("PLACANJE");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.TipPlacanja, "TIP_PLACANJA");
        }
    }
}
