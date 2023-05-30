using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class KorisnikMapiranja : ClassMap<Korisnik>
    {
        public KorisnikMapiranja()
        {
            Table("KORISNIK");

            //DiscriminateSubClassesOnColumn("TIP_KORISNIKA");

            Id(x => x.JMBG, "JMBG").GeneratedBy.Assigned();

            Map(x => x.Broj, "BROJ");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Tip_korisnika, "TIP_KORISNIKA");
            //broj ugovora se racuna !!!

            Map(x => x.Grad, "GRAD");

            References(x => x.Kom_cvor).Column("KOM_CVOR").LazyLoad();

            HasMany(x => x.Korisnik_koristi).KeyColumn("JMBG_KORISNIKA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Telefoni_korinika).KeyColumn("JMBG_KORISNIKA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
