using System.Collections.Generic;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TelevizijaView:UslugaView
    {
        public string Paket { get; set; }
        public IList<DodatniPaketKanalaView> DodatniPaketiKanala { get; set; }
        public TelevizijaView()
        {
            DodatniPaketiKanala = new List<DodatniPaketKanalaView>();
        }
        public TelevizijaView(Televizija t):base(t)
        {
            Paket = t.Paket;
        }
    }
}
