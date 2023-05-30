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
    class FizickaLicaMapiranja:SubclassMap<Fizicka_lica>
    {
        public FizickaLicaMapiranja()
        {
            Table("FIZICKA_LICA");
            KeyColumn("JMBG");
        }
    }
}
