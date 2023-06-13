using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PlacanjeView
    {
        public int Id { get; set; }
        public string TipPlacanja { get; set; }
        public PlacanjeView()
        {
            
        }
        public PlacanjeView(Placanje p)
        {
            Id = p.Id;
            TipPlacanja = p.TipPlacanja;
        }
    }
}
