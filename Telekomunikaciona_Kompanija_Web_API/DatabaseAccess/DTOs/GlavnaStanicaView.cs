using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class GlavnaStanicaView : UredjajView
    {
        public  bool Flag_Hub { get; set; }
        public  string Region { get; set; }
        public  GlavnaStanicaView Glavna_stanica_hub { get; set; }
        public IList<GlavnaStanicaView> Hub_glavna_stanica { get; set; }
        public IList<KomunikacioniCvorView> Komunikacioni_cvor { get; set; }
        public GlavnaStanicaView()
        {
            Flag_Hub = false;
            Hub_glavna_stanica = new List<GlavnaStanicaView>();
            Komunikacioni_cvor = new List<KomunikacioniCvorView>();
        }

        public GlavnaStanicaView(Glavna_stanica gs):base(gs)
        {
            Flag_Hub=gs.Flag_Hub;
            Region= gs.Region;
        }
    }
}
