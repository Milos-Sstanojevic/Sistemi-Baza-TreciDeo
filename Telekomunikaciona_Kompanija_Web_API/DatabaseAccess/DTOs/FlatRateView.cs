using System.Collections.Generic;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class FlatRateView:PlacanjeView
    {
        public IList<StatickaAdresaView> StatickeAdrese { get; set; }
        public FlatRateView()
        {
            StatickeAdrese = new List<StatickaAdresaView>();
        }
        public FlatRateView(FlatRate p):base(p)
        {
            
        }
    }
}
