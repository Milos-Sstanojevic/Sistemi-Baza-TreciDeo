using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class BrojTelefonaView
    {
        public int Id { get; set; }
        public int Broj { get; set; }
        public int Potroseni_minuti { get; set; }
        public TelefonijaView PripadaTelefoniji { get; set; }
        public BrojTelefonaView()
        {
            
        }
        public BrojTelefonaView(BrojTelefona t)
        {
            Id = t.Id;
            Broj = t.Broj;
            Potroseni_minuti = t.Potroseni_minuti;
        }
    }
}
