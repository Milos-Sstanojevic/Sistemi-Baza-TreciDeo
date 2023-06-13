using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TelefonijaView:UslugaView
    {
        public  IList<BrojTelefonaView> Brojevi_Telefona { get; set; }

        public TelefonijaView()
        {
            Brojevi_Telefona = new List<BrojTelefonaView>();
        }
        public TelefonijaView(Telefonija t): base(t)
        {
            
        }
    }
}
