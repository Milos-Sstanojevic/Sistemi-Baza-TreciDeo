using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class KomunikacioniCvorMapiranja : SubclassMap<Komunikacioni_cvor>
    {
        public KomunikacioniCvorMapiranja()
        {
            Table("KOMUNIKACIONI_CVOR");

            KeyColumn("SERIJSKI_BROJ");

            Map(x => x.Broj_lokacije, "BROJ_LOKACIJE");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Adresa, "ADRESA");

            References(x => x.Glavna_stanica_kom_cvora).Column("GLAVNA_STANICA_KOM_CVORA").LazyLoad();

            HasMany(x => x.Korisnik).KeyColumn("KOM_CVOR").LazyLoad().Cascade.All().Inverse();
        }
    }
}
