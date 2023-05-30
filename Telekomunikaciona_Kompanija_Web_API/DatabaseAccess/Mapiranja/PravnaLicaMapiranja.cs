using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    class PravnaLicaMapiranja:SubclassMap<Pravna_lica>
    {
        public PravnaLicaMapiranja() {
            Table("PRAVNA_LICA");
            KeyColumn("JMBG");

            Map(x => x.Ime_kontakt_osobe, "IME_KONTAKT_OSOBE");
            Map(x => x.Broj_faksa, "BROJ_FAKSA");
            Map(x => x.Poreski_identifikacioni_broj, "PORESKI_IDENTIFIKACIONI_BROJ");
        }
    }
}
