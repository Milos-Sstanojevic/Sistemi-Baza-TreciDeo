using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class StatickaAdresaView
    {
        public int Id { get; set; }
        public string Staticka_Adresa { get; set; }
        public FlatRateView FlatRate { get; set; }
        public StatickaAdresaView()
        {
            
        }
        public StatickaAdresaView(StatickaAdresa sa)
        {
            Id = sa.Id;
            Staticka_Adresa=sa.Staticka_Adresa;
        }
    }
}
