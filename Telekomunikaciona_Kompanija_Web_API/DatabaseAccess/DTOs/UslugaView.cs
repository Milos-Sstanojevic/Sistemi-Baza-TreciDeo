using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class UslugaView
    {
        public int Id { get; set; }
        public string Tip_usluge { get; set; }
        public IList<KoristiView> Uslugu_koristi { get; set; }

        public UslugaView()
        {
            Uslugu_koristi = new List<KoristiView>();
        }

        public UslugaView(Usluga u)
        {
            Id = u.Id;
            Tip_usluge = u.Tip_usluge;
        }
    }
}
