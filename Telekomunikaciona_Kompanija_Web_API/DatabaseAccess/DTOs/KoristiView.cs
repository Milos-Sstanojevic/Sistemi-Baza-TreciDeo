using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KoristiView
    {
        public int Id { get; set; }
        public Korisnik JMBG_Korisnika { get; set; }
        public Usluga ID_Usluge { get; set; }

        public KoristiView() { }

        public KoristiView(Koristi k)
        {
            Id= k.Id;
        }
    }
}
