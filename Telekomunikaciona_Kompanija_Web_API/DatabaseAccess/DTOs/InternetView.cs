using System;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class InternetView:UslugaView
    {
        public string TipInterneta { get; set; }
        public bool FlagPrepaid { get; set; }

        public DateTime DatumPoslednjeUplate { get; set; }
        public int StanjeRacuna { get; set; }
        public PlacanjeView Placanje { get; set; }
        public InternetView()
        {
            
        }
        public InternetView(Internet i):base(i)
        {
            TipInterneta = i.TipInterneta;
            FlagPrepaid= i.FlagPrepaid;
            DatumPoslednjeUplate=i.DatumPoslednjeUplate;
            StanjeRacuna = i.StanjeRacuna;
        }
    }
}
