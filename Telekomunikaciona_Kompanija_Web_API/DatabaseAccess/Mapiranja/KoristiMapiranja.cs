using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class KoristiMapiranja:ClassMap<Koristi>
    {
        public KoristiMapiranja() {
            Table("KORISTI");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.JMBG_Korisnika).Column("JMBG_KORISNIKA").LazyLoad();

            References(x => x.ID_Usluge).Column("ID_USLUGE").LazyLoad();
        }
    }
}
