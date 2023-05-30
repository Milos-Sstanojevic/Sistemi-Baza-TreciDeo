using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace Telekomunikaciona_Kompanija_NHibernate.Mapiranja
{
    public class TelefonijaMapiranja : SubclassMap<Telefonija>
    {
        public TelefonijaMapiranja()
        {
            Table("TELEFONIJA");

            KeyColumn("ID_USLUGE");

            HasMany(x => x.Brojevi_Telefona).KeyColumn("TELEFONIJA").LazyLoad().Inverse().Cascade.All();
        }
    }
}
