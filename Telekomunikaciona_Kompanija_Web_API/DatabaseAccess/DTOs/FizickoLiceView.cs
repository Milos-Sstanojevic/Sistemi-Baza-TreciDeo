using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class FizickoLiceView:KorisnikView
    {
        public FizickoLiceView() { }
        public FizickoLiceView(Fizicka_lica f):base(f) { }
    }
}
