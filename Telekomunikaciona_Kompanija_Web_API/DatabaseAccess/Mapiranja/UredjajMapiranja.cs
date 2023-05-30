using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class UredjajMapiranja:ClassMap<Telekomunikaciona_Kompanija_NHibernate.Entiteti.Uredjaj>
    {
        public UredjajMapiranja()
        {
            Table("UREDJAJ");

            Id(x => x.Serijski_broj).Column("SERIJSKI_BROJ").GeneratedBy.Assigned();

            Map(x => x.Tip_uredjaja).Column("TIP_UREDJAJA");
            Map(x => x.Datum_pocetka_upotrebe).Column("DATUM_POCETKA_UPOTREBE");
            Map(x => x.Razlog_poslednjeg_servisa).Column("RAZLOG_POSLEDNJEG_SERVISA");
            Map(x => x.Proizvodjac).Column("PROIZVODJAC");
        }
    }
}
