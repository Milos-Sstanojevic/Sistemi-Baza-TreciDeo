using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class DodatniPaketKanalaView
    {
        public virtual int Id { get; set; }
        public virtual string DodatniPaket { get; set; }
        public virtual TelevizijaView Televizija { get; set; }
        public DodatniPaketKanalaView()
        {
            
        }
        public DodatniPaketKanalaView(DodatniPaketKanala paket)
        {
            Id = paket.Id;
            DodatniPaket=paket.DodatniPaket;
        }
    }
}
