using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class OstvareniProtokView : PlacanjeView
    {
        public int Protok { get; set; }
        public OstvareniProtokView()
        {
            
        }
        public OstvareniProtokView(OstvareniProtok op):base(op)
        {
            Protok = op.Protok;
        }
    }
}
