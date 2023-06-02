using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TelefonView
    {
        public int Id { get; set; }
        public KorisnikView JMBG_korisnika { get; set; }
        public long telefon { get; set; }

        public TelefonView() { }

        public TelefonView(Telefon t)
        {
            Id = t.Id;
            telefon = t.telefon;
        }
    }
}
