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
    public class InternetMapiranja : SubclassMap<Internet>
    {
        public InternetMapiranja()
        {
            Table("INTERNET");

            KeyColumn("ID_USLUGE");

            Map(x => x.TipInterneta, "TIP_INTERNETA");
            Map(x => x.FlagPrepaid, "FLAG_PREPAID");
            Map(x => x.DatumPoslednjeUplate, "DATUM_POSLEDNJE_UPLATE");
            Map(x => x.StanjeRacuna, "STANJE_RACUNA");

            References(x => x.Placanje).Column("PLACANJE_INTERNETA").Unique().Cascade.All();
            //HasOne(x => x.Placanje).PropertyRef(x => x.Id);
        }
    }
}
