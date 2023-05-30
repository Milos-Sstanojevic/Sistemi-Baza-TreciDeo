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
    public class TelevizijaMapiranja : SubclassMap<Televizija>
    {
        public TelevizijaMapiranja()
        {
            Table("TELEVIZIJA");

            KeyColumn("ID_USLUGE");

            Map(x => x.Paket, "PAKET");

            HasMany(x => x.DodatniPaketiKanala).KeyColumn("TELEVIZIJA").LazyLoad().Inverse().Cascade.All();
        }
    }
}
