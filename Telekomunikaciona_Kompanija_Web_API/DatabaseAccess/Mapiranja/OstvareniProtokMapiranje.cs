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
    public class OstvareniProtokMapiranje: SubclassMap<OstvareniProtok>
    {
        public OstvareniProtokMapiranje()
        {
            Table("OSTVAREN_PROTOK");

            KeyColumn("ID_PLACANJA");

            Map(x => x.Protok, "KOLICINA_OSTAVRENOG_PROTOKA");
        }
    }
}
