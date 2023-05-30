using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class TelefonMapiranja:ClassMap<Telefon>
    {
        public TelefonMapiranja() {
            Table("TELEFON");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.telefon, "TELEFON");

            References(x => x.JMBG_korisnika).Column("JMBG_KORISNIKA").LazyLoad();
        }
    }
}
