using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class DodatniPaketKanalaMapiranja :ClassMap<DodatniPaketKanala>
    {
        public DodatniPaketKanalaMapiranja()
        {
            Table("DODATNI_PAKET_KANALA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DodatniPaket, "DODATNI_PAKET_KANALA");

            References(x=>x.Televizija).Column("TELEVIZIJA").LazyLoad();
        }
    }
}
