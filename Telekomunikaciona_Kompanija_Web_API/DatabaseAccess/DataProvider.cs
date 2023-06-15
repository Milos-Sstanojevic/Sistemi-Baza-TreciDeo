using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telekomunikaciona_Kompanija_NHibernate.Entiteti;
using Telekomunikaciona_Kompanija_NHibernate;
using NHibernate;
using DatabaseAccess.DTOs;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region Uredjaji



        public static void obrisiUredjaj(long serBr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Uredjaj u = s.Load<Uredjaj>(serBr);

                s.Delete(u);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static List<UredjajView> vratiSveUredjaje()
        {
            List<UredjajView> uredjaji = new List<UredjajView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Telekomunikaciona_Kompanija_NHibernate.Entiteti.Uredjaj> sviUredjaji = from u in s.Query<Telekomunikaciona_Kompanija_NHibernate.Entiteti.Uredjaj>()
                                                                                                   select u;

                foreach (Uredjaj u in sviUredjaji)
                {
                    uredjaji.Add(new UredjajView(u));
                }

                s.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return uredjaji;
        }

        public static void dodajHub(GlavnaStanicaView glavna)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica gs = new Glavna_stanica();

                gs.Tip_uredjaja = glavna.Tip_uredjaja;
                gs.Serijski_broj = glavna.Serijski_broj;
                gs.Proizvodjac = glavna.Proizvodjac;
                gs.Datum_pocetka_upotrebe = glavna.Datum_pocetka_upotrebe;
                gs.Razlog_poslednjeg_servisa = glavna.Razlog_poslednjeg_servisa;
                gs.Region = glavna.Region;
                gs.Flag_Hub = glavna.Flag_Hub;
                gs.Hub_glavna_stanica = new List<Glavna_stanica>();

                s.SaveOrUpdate(gs);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodajGS(GlavnaStanicaView glavna, long serBrHuba)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica gs = new Glavna_stanica();

                gs.Tip_uredjaja = "Glavna stanica";
                gs.Serijski_broj = glavna.Serijski_broj;
                gs.Proizvodjac = glavna.Proizvodjac;
                gs.Datum_pocetka_upotrebe = glavna.Datum_pocetka_upotrebe;
                gs.Razlog_poslednjeg_servisa = glavna.Razlog_poslednjeg_servisa;
                gs.Flag_Hub = glavna.Flag_Hub;
                gs.Glavna_stanica_hub = s.Load<Glavna_stanica>(serBrHuba);
                gs.Hub_glavna_stanica = new List<Glavna_stanica>();

                s.SaveOrUpdate(gs);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodajKC(KomunikacioniCvorView cvor,long serBrGS)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor kc = new Komunikacioni_cvor();

                kc.Tip_uredjaja = "Komunikacioni cvor";
                kc.Serijski_broj = cvor.Serijski_broj;
                kc.Proizvodjac = cvor.Proizvodjac;
                kc.Datum_pocetka_upotrebe = cvor.Datum_pocetka_upotrebe;
                kc.Razlog_poslednjeg_servisa = cvor.Razlog_poslednjeg_servisa;
                kc.Broj_lokacije = cvor.Broj_lokacije;
                kc.Adresa = cvor.Adresa;
                kc.Opis = cvor.Opis;
                kc.Glavna_stanica_kom_cvora = s.Load<Glavna_stanica>(serBrGS);
                kc.Korisnik = new List<Korisnik>();


                s.Save(kc);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<GlavnaStanicaView> vratiGlavneStanice()
        {
            List<GlavnaStanicaView> gStanice = new List<GlavnaStanicaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Glavna_stanica> gs = from g in s.Query<Glavna_stanica>() select g;

                foreach (Glavna_stanica g in gs)
                {
                    gStanice.Add(new GlavnaStanicaView(g));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return gStanice;
        }

        public static UredjajView vratiUredjaj(long serijskiBrojUredjaja)
        {
            UredjajView ub = new UredjajView();

            try
            {
                ISession s = DataLayer.GetSession();

                Uredjaj u = s.Load<Uredjaj>(serijskiBrojUredjaja);

                ub = new UredjajView(u);

                s.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ub;
        }

        public static GlavnaStanicaView vratiGS(long serijski_broj)
        {
            GlavnaStanicaView ub = new GlavnaStanicaView();

            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica u = s.Load<Glavna_stanica>(serijski_broj);

                ub = new GlavnaStanicaView(u);

                s.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ub;
        }

        public static List<KomunikacioniCvorView> vratiAdreseKomCvorova(long serijski_broj)
        {
            List<KomunikacioniCvorView> komCvorovi = new List<KomunikacioniCvorView>();
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica glavna_Stanica = s.Load<Glavna_stanica>(serijski_broj);

                foreach (Komunikacioni_cvor komCvor in glavna_Stanica.Komunikacioni_cvor)
                {
                    komCvorovi.Add(new KomunikacioniCvorView(komCvor));
                }
                s.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            return komCvorovi;
        }
        public static List<GlavnaStanicaView> vratiHubove()
        {
            List<GlavnaStanicaView> hubovi = new List<GlavnaStanicaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Glavna_stanica> gs = from g in s.Query<Glavna_stanica>() where g.Flag_Hub == true select g;

                foreach (Glavna_stanica g in gs)
                {
                    hubovi.Add(new GlavnaStanicaView(g));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return hubovi;
        }

        public static GlavnaStanicaView vratiHubOdabraneStanice(long serijski_broj)
        {
            GlavnaStanicaView glavna_Stanica = new GlavnaStanicaView();

            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica gs = s.Load<Glavna_stanica>(serijski_broj);

                Glavna_stanica hub = s.Load<Glavna_stanica>(gs.Glavna_stanica_hub.Serijski_broj);

                glavna_Stanica = new GlavnaStanicaView(hub);
            }
            catch (System.Exception e) { Console.WriteLine(e.Message); }

            return glavna_Stanica;
        }

        public static List<GlavnaStanicaView> vratiGlavneStaniceHuba(long serijski_broj)
        {
            List<GlavnaStanicaView> glavne_stanice = new List<GlavnaStanicaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica glavna_stanica = s.Load<Glavna_stanica>(serijski_broj);

                foreach (Glavna_stanica gs in glavna_stanica.Hub_glavna_stanica)
                {
                    glavne_stanice.Add(new GlavnaStanicaView(gs));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return glavne_stanice;
        }

        public static KomunikacioniCvorView vratiKCBasic(long serijski_broj)
        {
            KomunikacioniCvorView ub = new KomunikacioniCvorView();

            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor u = s.Load<Komunikacioni_cvor>(serijski_broj);

                ub = new KomunikacioniCvorView(u);

                s.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ub;
        }

        public static KomunikacioniCvorView vratiKC(long serijski_broj)
        {
            KomunikacioniCvorView ub = new KomunikacioniCvorView();

            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor u = s.Load<Komunikacioni_cvor>(serijski_broj);

                ub = new KomunikacioniCvorView(u);

                s.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ub;
        }

        public static GlavnaStanicaView vratiGlavnuStanicuKC(long serijski_broj)
        {
            GlavnaStanicaView glavna_Stanica = new GlavnaStanicaView();
            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(serijski_broj);

                Glavna_stanica gs = kc.Glavna_stanica_kom_cvora;

                glavna_Stanica = new GlavnaStanicaView(gs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return glavna_Stanica;
        }

        public static List<KorisnikView> vratiKorisnikeKC(long serijski_broj)
        {
            List<KorisnikView> korisnici = new List<KorisnikView>();

            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(serijski_broj);

                IEnumerable<Korisnik> sviKorisnici = from k in s.Query<Korisnik>() where k.Kom_cvor == kc select k;

                foreach (Korisnik k in sviKorisnici)
                {
                    korisnici.Add(new KorisnikView(k));
                }

                s.Close();
            }
            catch (System.Exception e)
            {
                Console.Write(e.ToString());
            }

            return korisnici;
        }
        #endregion

        #region Korisnik

        public static void obrisiKorisnika(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = s.Load<Korisnik>(JMBG);

                s.Delete(k);
                s.Flush();

                s.Close();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodajPravnoLice(PravnoLiceView p,long serBrKC)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pravna_lica lice = new Pravna_lica();

                lice.JMBG = p.JMBG;
                lice.Ime = p.Ime;
                lice.Prezime = p.Prezime;
                lice.Broj = p.Broj;
                lice.Adresa = p.Adresa;
                lice.Grad = p.Grad;
                lice.Broj_faksa = p.Broj_faksa;
                lice.Poreski_identifikacioni_broj = p.Poreski_identifikacioni_broj;
                lice.Tip_korisnika = p.Tip_korisnika;
                lice.Ime_kontakt_osobe = p.Ime_kontakt_osobe;
                lice.Korisnik_koristi = new List<Koristi>();
                lice.Telefoni_korinika = new List<Telefon>();
                lice.Kom_cvor = s.Load<Komunikacioni_cvor>(serBrKC);


                s.Save(lice);
                s.Flush();

                /*                DTOmanagerM.dodajKCKorisniku(lice.JMBG, p.Kom_cvor);*/

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodajFizickoLice(FizickoLiceView p,long serBrKc)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Fizicka_lica lice = new Fizicka_lica();

                lice.JMBG = p.JMBG;
                lice.Ime = p.Ime;
                lice.Prezime = p.Prezime;
                lice.Broj = p.Broj;
                lice.Adresa = p.Adresa;
                lice.Grad = p.Grad;
                lice.Tip_korisnika = p.Tip_korisnika;

                lice.Kom_cvor = s.Load<Komunikacioni_cvor>(serBrKc);

                s.Save(lice);
                s.Flush();


                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodajKCKorisniku(string JMBG, KomunikacioniCvorView kom_cvor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik korisnik = s.Load<Korisnik>(JMBG);

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(kom_cvor.Serijski_broj);

                korisnik.Kom_cvor = kc;

                s.Save(korisnik);

                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<KorisnikView> vratiSveKorisnike()
        {
            List<KorisnikView> korisnici = new List<KorisnikView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Korisnik> korisnik = from k in s.Query<Telekomunikaciona_Kompanija_NHibernate.Entiteti.Korisnik>()
                                                 select k;

                foreach (Korisnik k in korisnik)
                {
                    korisnici.Add(new KorisnikView(k));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return korisnici;
        }

        public static void promeniKorisnikaFizickoLice(FizickoLiceView korisnik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Fizicka_lica p = s.Load<Fizicka_lica>(korisnik.JMBG);
                p.Ime = korisnik.Ime;
                p.Prezime = korisnik.Prezime;
                p.Adresa = korisnik.Adresa;
                p.Broj = korisnik.Broj;
                p.Grad = korisnik.Grad;

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void promeniKorisnikaPravnoLice(PravnoLiceView korisnik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pravna_lica p = s.Load<Pravna_lica>(korisnik.JMBG);
                p.Ime = korisnik.Ime;
                p.Prezime = korisnik.Prezime;
                p.Adresa = korisnik.Adresa;
                p.Broj = korisnik.Broj;
                p.Grad = korisnik.Grad;
                p.Poreski_identifikacioni_broj = korisnik.Poreski_identifikacioni_broj;
                p.Broj_faksa = korisnik.Broj_faksa;
                p.Ime_kontakt_osobe = korisnik.Ime_kontakt_osobe;

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static KorisnikView vratiKorisnika(string JMBG)
        {
            KorisnikView ub = new KorisnikView();

            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik u = s.Load<Korisnik>(JMBG);

                ub = new KorisnikView(u);

                s.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ub;
        }

        public static FizickoLiceView vratiFizickoLiceBasic(string JMBG)
        {
            FizickoLiceView pravnoLice = new FizickoLiceView();

            try
            {
                ISession s = DataLayer.GetSession();

                Fizicka_lica p = s.Load<Fizicka_lica>(JMBG);

                pravnoLice = new FizickoLiceView(p);

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pravnoLice;
        }

        public static PravnoLiceView vratiPravnoLice(string JMBG)
        {
            PravnoLiceView pravnoLice = new PravnoLiceView();

            try
            {
                ISession s = DataLayer.GetSession();

                Pravna_lica p = s.Load<Pravna_lica>(JMBG);

                pravnoLice = new PravnoLiceView(p);

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pravnoLice;
        }

        public static KomunikacioniCvorView vratiKCKorisnika(string JMBG)
        {
            KomunikacioniCvorView kc_Pregled = new KomunikacioniCvorView();

            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik korisnik = s.Load<Korisnik>(JMBG);

                Komunikacioni_cvor kc = korisnik.Kom_cvor;

                kc_Pregled = new KomunikacioniCvorView(kc);

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return kc_Pregled;
        }

        public static List<TelefonView> vratiTelefoneKorisnika(string JMBG)
        {
            List<TelefonView> telefoni = new List<TelefonView>();

            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik korisnik = s.Load<Korisnik>(JMBG);

                IEnumerable<Telefon> tel = from k in s.Query<Telefon>() where k.JMBG_korisnika == korisnik select k;

                foreach (Telefon t in tel)
                {
                    telefoni.Add(new TelefonView(t));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return telefoni;
        }

        public static List<UslugaView> vratiUslugeKorisnika(string JMBG)
        {
            List<UslugaView> usluge = new List<UslugaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik korisnik = s.Load<Korisnik>(JMBG);

                IEnumerable<Koristi> koristi = from k in s.Query<Koristi>() where k.JMBG_Korisnika.JMBG == korisnik.JMBG select k;

                foreach (Koristi k in koristi)
                {
                    usluge.Add(vratiUslugu(k.ID_Usluge.Id));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return usluge;
        }

        #endregion

        #region Usluga

        public static UslugaView vratiUslugu(int id)
        {
            UslugaView usluga = new UslugaView();
            try
            {
                ISession s = DataLayer.GetSession();

                Usluga u = s.Load<Usluga>(id);

                usluga = new UslugaView(u);

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return usluga;
        }


        public static void otkaziUsluguKorisniku(int Id, string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Usluga u = s.Load<Usluga>(Id);

                Korisnik k = s.Load<Korisnik>(jmbg);

                IEnumerable<Koristi> koristiList = from kor in s.Query<Koristi>() where kor.JMBG_Korisnika == k && kor.ID_Usluge == u select kor;

                Koristi jedan = koristiList.First();

                Koristi koristi = s.Load<Koristi>(jedan.Id);

                s.Delete(koristi);
                s.Flush();

                s.Update(k);
                s.Flush();

                s.Update(u); s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void dodeliUsluguKorisniku(int Id, string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Usluga u = s.Load<Usluga>(Id);

                Korisnik k = s.Load<Korisnik>(JMBG);

                Koristi koristi = new Koristi();

                koristi.JMBG_Korisnika = k;
                koristi.ID_Usluge = u;

                s.SaveOrUpdate(koristi);
                s.Flush();

                k.Korisnik_koristi.Add(koristi);

                s.SaveOrUpdate(k);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void kreirajTelefonIDodeliKorisniku(string telefon, string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = s.Load<Korisnik>(JMBG);

                Telefon t = new Telefon();

                t.telefon = long.Parse(telefon);
                t.JMBG_korisnika = k;

                s.SaveOrUpdate(t);
                s.Flush();

                k.Telefoni_korinika.Add(t);

                s.SaveOrUpdate(k);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<UslugaView> vratiUsluge()
        {
            List<UslugaView> usluge = new List<UslugaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Usluga> usl = from u in s.Query<Usluga>() select u;

                foreach (Usluga u in usl)
                {
                    usluge.Add(new UslugaView(u));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return usluge;
        }

        #endregion

        #region GlavnaStanica

        public static void promeniHubGSe(long h, long gs)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(gs);
                Glavna_stanica hub = s.Load<Glavna_stanica>(h);

                g.Glavna_stanica_hub = hub;

                hub.Hub_glavna_stanica.Add(g);

                s.Update(g);
                s.Flush();

                s.Update(hub);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void proglasiZaHub(long ser)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(ser);

                g.Flag_Hub = true;
                g.Glavna_stanica_hub = null;
                g.Tip_uredjaja = "Hub";

                s.Update(g);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void promeniGS(GlavnaStanicaView glavna)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(glavna.Serijski_broj);

                g.Proizvodjac = glavna.Proizvodjac;
                g.Datum_pocetka_upotrebe = glavna.Datum_pocetka_upotrebe;
                g.Razlog_poslednjeg_servisa = glavna.Razlog_poslednjeg_servisa;

                s.Update(g);
                s.Flush();

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Hub
        public static void poveziGSNaHub(long stanica, long hub)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica st = s.Load<Glavna_stanica>(stanica);
                Glavna_stanica h = s.Load<Glavna_stanica>(hub);

                h.Hub_glavna_stanica.Add(st);
                st.Glavna_stanica_hub = h;

                s.Update(st);
                s.Flush();

                s.Update(h);
                s.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void odveziGSSaHuba(long stanica, long hub)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica st = s.Load<Glavna_stanica>(stanica);
                Glavna_stanica h = s.Load<Glavna_stanica>(hub);

                h.Hub_glavna_stanica.Remove(st);
                st.Glavna_stanica_hub = null;

                s.Update(st);
                s.Flush();

                s.Update(h);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void promeniHub(GlavnaStanicaView hub)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(hub.Serijski_broj);

                g.Proizvodjac = hub.Proizvodjac;
                g.Datum_pocetka_upotrebe = hub.Datum_pocetka_upotrebe;
                g.Razlog_poslednjeg_servisa = hub.Razlog_poslednjeg_servisa;
                g.Region = hub.Region;

                s.Update(g);
                s.Flush();

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region KomCvor

        public static void dodajKCGS(long kc, long gs)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(gs);
                Komunikacioni_cvor k = s.Load<Komunikacioni_cvor>(kc);

                k.Glavna_stanica_kom_cvora = g;

                s.Update(g);
                s.Flush();

                s.Update(k);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static List<KomunikacioniCvorView> vratiKCvoroveGS(long ser)
        {
            List<KomunikacioniCvorView> cvorovi = new List<KomunikacioniCvorView>();
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica g = s.Load<Glavna_stanica>(ser);

                foreach (Komunikacioni_cvor k in g.Komunikacioni_cvor)
                {
                    cvorovi.Add(new KomunikacioniCvorView(k));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cvorovi;
        }

        public static void promeniKC(KomunikacioniCvorView kom)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(kom.Serijski_broj);

                kc.Proizvodjac = kom.Proizvodjac;
                kc.Adresa = kom.Adresa;
                kc.Datum_pocetka_upotrebe = kom.Datum_pocetka_upotrebe;
                kc.Broj_lokacije = kom.Broj_lokacije;
                kc.Razlog_poslednjeg_servisa = kom.Razlog_poslednjeg_servisa;
                kc.Opis = kom.Opis;

                s.Update(kc);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void promeniGSKCa(long serGS, long serKC)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glavna_stanica gs = s.Load<Glavna_stanica>(serGS);

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(serKC);

                kc.Glavna_stanica_kom_cvora = gs;

                s.Update(gs);
                s.Flush();

                s.Update(kc);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void ukloniKorisnikaKCa(string jmbg, long ser)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik korisnik = s.Load<Korisnik>(jmbg);

                Komunikacioni_cvor kom = s.Load<Komunikacioni_cvor>(ser);

                kom.Korisnik.Remove(korisnik);

                s.Update(kom);
                s.Flush();

                s.Update(korisnik);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void dodajKorisnikaKCu(string jmbg, long ser)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = s.Load<Korisnik>(jmbg);

                Komunikacioni_cvor kom = s.Load<Komunikacioni_cvor>(ser);

                k.Kom_cvor = kom;

                s.Update(kom);
                s.Flush();

                s.Update(k);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void promeniKCKorisniku(string jmbg, long serBr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = s.Load<Korisnik>(jmbg);

                Komunikacioni_cvor kc = s.Load<Komunikacioni_cvor>(serBr);

                k.Kom_cvor = kc;

                s.Update(k);
                s.Flush();

                s.Update(kc);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<KomunikacioniCvorView> vratiKomCvorove()
        {
            List<KomunikacioniCvorView> komCvorovi = new List<KomunikacioniCvorView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Komunikacioni_cvor> kc = from k in s.Query<Komunikacioni_cvor>() select k;

                foreach (Komunikacioni_cvor k in kc)
                {
                    komCvorovi.Add(new KomunikacioniCvorView(k));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return komCvorovi;
        }

        #endregion

        #region Telefon

        public static List<TelefonView> vratiTelefone()
        {
            List<TelefonView> telefoni = new List<TelefonView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Telefon> tel = from t in s.Query<Telefon>() select t;

                foreach (Telefon t in tel)
                {
                    telefoni.Add(new TelefonView(t));
                }

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return telefoni;
        }

        public static void promeniTelefon(string novi, string stari)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Telefon> t = from tel in s.Query<Telefon>() where tel.telefon == long.Parse(stari) select tel;

                Telefon telefon = t.First();

                telefon.telefon = long.Parse(novi);

                s.Update(telefon);
                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        #endregion

        #region Telefonija
        public static void SacuvajTelefoniju(TelefonijaView tel)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Telefonija telefonija = new Telefonija();

                telefonija.Tip_usluge = tel.Tip_usluge;

                BrojTelefona broj = new BrojTelefona();

                broj.Potroseni_minuti = tel.Brojevi_Telefona[0].Potroseni_minuti;
                broj.Broj = tel.Brojevi_Telefona[0].Broj;
                broj.PripadaTelefoniji = telefonija;
                telefonija.Brojevi_Telefona.Add(broj);

                if (tel.Brojevi_Telefona.Count == 2)
                {
                    BrojTelefona br = new BrojTelefona();

                    br.Potroseni_minuti = tel.Brojevi_Telefona[1].Potroseni_minuti;
                    br.Broj = tel.Brojevi_Telefona[1].Broj;
                    br.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br);
                }
                else if (tel.Brojevi_Telefona.Count == 3)
                {
                    BrojTelefona br = new BrojTelefona();

                    br.Potroseni_minuti = tel.Brojevi_Telefona[1].Potroseni_minuti;
                    br.Broj = tel.Brojevi_Telefona[1].Broj;
                    br.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br);

                    BrojTelefona br1 = new BrojTelefona();

                    br1.Potroseni_minuti = tel.Brojevi_Telefona[2].Potroseni_minuti;
                    br1.Broj = tel.Brojevi_Telefona[2].Broj;
                    br1.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br1);
                }
                else
                {
                    BrojTelefona br = new BrojTelefona();

                    br.Potroseni_minuti = tel.Brojevi_Telefona[1].Potroseni_minuti;
                    br.Broj = tel.Brojevi_Telefona[1].Broj;
                    br.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br);

                    BrojTelefona br1 = new BrojTelefona();

                    br1.Potroseni_minuti = tel.Brojevi_Telefona[2].Potroseni_minuti;
                    br1.Broj = tel.Brojevi_Telefona[2].Broj;
                    br1.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br1);

                    BrojTelefona br2 = new BrojTelefona();

                    br2.Potroseni_minuti = tel.Brojevi_Telefona[3].Potroseni_minuti;
                    br2.Broj = tel.Brojevi_Telefona[3].Broj;
                    br2.PripadaTelefoniji = telefonija;
                    telefonija.Brojevi_Telefona.Add(br2);
                }

                s.Save(telefonija);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }


        public static TelefonijaView VratiTelefoniju(int id)
        {
            TelefonijaView tb = new TelefonijaView();
            try
            {
                ISession s = DataLayer.GetSession();

                Telefonija t = s.Load<Telefonija>(id);

                tb.Id = t.Id;
                tb.Tip_usluge = t.Tip_usluge;
                BrojTelefonaView br = new BrojTelefonaView();
                br.Id = t.Brojevi_Telefona[0].Id;
                br.Broj = t.Brojevi_Telefona[0].Broj;
                br.Potroseni_minuti = t.Brojevi_Telefona[0].Potroseni_minuti;
                br.PripadaTelefoniji = tb;
                tb.Brojevi_Telefona.Add(br);

                if (t.Brojevi_Telefona.Count == 2)
                {
                    BrojTelefonaView br1 = new BrojTelefonaView();
                    br1.Id = t.Brojevi_Telefona[1].Id;
                    br1.Broj = t.Brojevi_Telefona[1].Broj;
                    br1.Potroseni_minuti = t.Brojevi_Telefona[1].Potroseni_minuti;
                    br1.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br1);
                }
                else if (t.Brojevi_Telefona.Count == 3)
                {
                    BrojTelefonaView br1 = new BrojTelefonaView();
                    br1.Id = t.Brojevi_Telefona[1].Id;
                    br1.Broj = t.Brojevi_Telefona[1].Broj;
                    br1.Potroseni_minuti = t.Brojevi_Telefona[1].Potroseni_minuti;
                    br1.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br1);

                    BrojTelefonaView br2 = new BrojTelefonaView();
                    br2.Id = t.Brojevi_Telefona[2].Id;
                    br2.Broj = t.Brojevi_Telefona[2].Broj;
                    br2.Potroseni_minuti = t.Brojevi_Telefona[2].Potroseni_minuti;
                    br2.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br2);
                }
                else
                {
                    BrojTelefonaView br1 = new BrojTelefonaView();
                    br1.Id = t.Brojevi_Telefona[1].Id;
                    br1.Broj = t.Brojevi_Telefona[1].Broj;
                    br1.Potroseni_minuti = t.Brojevi_Telefona[1].Potroseni_minuti;
                    br1.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br1);

                    BrojTelefonaView br2 = new BrojTelefonaView();
                    br2.Id = t.Brojevi_Telefona[2].Id;
                    br2.Broj = t.Brojevi_Telefona[2].Broj;
                    br2.Potroseni_minuti = t.Brojevi_Telefona[2].Potroseni_minuti;
                    br2.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br2);

                    BrojTelefonaView br3 = new BrojTelefonaView();
                    br3.Id = t.Brojevi_Telefona[3].Id;
                    br3.Broj = t.Brojevi_Telefona[3].Broj;
                    br3.Potroseni_minuti = t.Brojevi_Telefona[3].Potroseni_minuti;
                    br3.PripadaTelefoniji = tb;
                    tb.Brojevi_Telefona.Add(br3);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return tb;
        }

        public static void IzmeniTelefoniju(TelefonijaView tel)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Telefonija t = s.Load<Telefonija>(tel.Id);

                if (tel.Brojevi_Telefona.Count >= t.Brojevi_Telefona.Count)
                {
                    for (int i = 0; i < t.Brojevi_Telefona.Count; i++)
                    {
                        t.Brojevi_Telefona[i].Broj = tel.Brojevi_Telefona[i].Broj;
                        t.Brojevi_Telefona[i].Potroseni_minuti = tel.Brojevi_Telefona[i].Potroseni_minuti;
                    }
                    for (int i = t.Brojevi_Telefona.Count; i < tel.Brojevi_Telefona.Count; i++)
                    {
                        BrojTelefona broj = new BrojTelefona();
                        broj.Broj = tel.Brojevi_Telefona[i].Broj;
                        broj.Potroseni_minuti = tel.Brojevi_Telefona[i].Potroseni_minuti;
                        broj.PripadaTelefoniji = t;
                        t.Brojevi_Telefona.Add(broj);
                    }
                }
                else
                {
                    for (int i = 0; i < tel.Brojevi_Telefona.Count; i++)
                    {
                        t.Brojevi_Telefona[i].Broj = tel.Brojevi_Telefona[i].Broj;
                        t.Brojevi_Telefona[i].Potroseni_minuti = tel.Brojevi_Telefona[i].Potroseni_minuti;
                    }
                    for (int i = t.Brojevi_Telefona.Count - 1; i > tel.Brojevi_Telefona.Count - 1; i--)
                    {
                        s.Delete(t.Brojevi_Telefona[i]);
                        t.Brojevi_Telefona.RemoveAt(i);
                    }
                }

                s.SaveOrUpdate(t);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiTelefoniju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Telefonija telefonija = s.Load<Telefonija>(id);

                s.Delete(telefonija);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region Televizija
        public static List<TelevizijaView> VratiTelevizije()
        {
            List<TelevizijaView> telefonije = new List<TelevizijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Televizija> tel = s.Query<Televizija>();

                foreach (Televizija t in tel)
                {
                    telefonije.Add(new TelevizijaView(t));
                }

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return telefonije;
        }

        public static void SacuvajTeleviziju(TelevizijaView tel)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Televizija televizija = new Televizija();

                televizija.Tip_usluge = tel.Tip_usluge;
                televizija.Paket = tel.Paket;

                s.Save(televizija);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static TelevizijaView VratiTeleviziju(int id)
        {
            TelevizijaView tb = new TelevizijaView();
            try
            {
                ISession s = DataLayer.GetSession();

                Televizija t = s.Load<Televizija>(id);

                tb.Id = t.Id;
                tb.Tip_usluge = t.Tip_usluge;
                tb.Paket = t.Paket;

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tb;
        }

        public static void IzmeniTeleviziju(TelevizijaView tb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Televizija t = s.Load<Televizija>(tb.Id);

                t.Paket = tb.Paket;

                s.SaveOrUpdate(t);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiTeleviziju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Televizija t = s.Load<Televizija>(id);

                s.Delete(t);

                s.Flush();

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Dodatni paketi kanala
        public static List<DodatniPaketKanalaView> VratiDodatnePakete(int televizija)
        {
            List<DodatniPaketKanalaView> paketi = new List<DodatniPaketKanalaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DodatniPaketKanala> p = from o in s.Query<DodatniPaketKanala>()
                                                    where o.Televizija.Id == televizija
                                                    select o;
                foreach (DodatniPaketKanala paket in p)
                {
                    paketi.Add(new DodatniPaketKanalaView(paket));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return paketi;
        }

        public static void SacuvajDodatniPaket(DodatniPaketKanalaView paket)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DodatniPaketKanala kanal = new DodatniPaketKanala();

                kanal.DodatniPaket = paket.DodatniPaket;

                Televizija t = s.Load<Televizija>(paket.Televizija.Id);
                kanal.Televizija = t;

                s.Save(kanal);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static DodatniPaketKanalaView VratiDodatniPaket(int id)
        {
            DodatniPaketKanalaView d = new DodatniPaketKanalaView();
            try
            {
                ISession s = DataLayer.GetSession();

                DodatniPaketKanala paket = s.Load<DodatniPaketKanala>(id);

                d.Id = paket.Id;
                d.DodatniPaket = paket.DodatniPaket;

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return d;
        }

        public static void IzmeniDodatniPaket(DodatniPaketKanalaView paket)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DodatniPaketKanala p = s.Load<DodatniPaketKanala>(paket.Id);

                p.DodatniPaket = paket.DodatniPaket;
                Televizija t = s.Load<Televizija>(paket.Televizija.Id);
                p.Televizija = t;

                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiDodatniPaketKanala(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DodatniPaketKanala p = s.Load<DodatniPaketKanala>(id);

                s.Delete(p);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Internet
        public static List<InternetView> VratiInternete()
        {
            List<InternetView> interneti = new List<InternetView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Internet> i = s.Query<Internet>();

                foreach (Internet p in i)
                {
                    interneti.Add(new InternetView(p));
                }
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return interneti;
        }

        public static void SacuvajInternet(InternetView net, OstvareniProtokView placanje, FlatRateView pl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Internet n = new Internet();
                n.Tip_usluge = net.Tip_usluge;
                n.TipInterneta = net.TipInterneta;
                n.FlagPrepaid = net.FlagPrepaid;
                n.DatumPoslednjeUplate = net.DatumPoslednjeUplate;
                n.StanjeRacuna = net.StanjeRacuna;


                if (placanje != null)
                {
                    OstvareniProtok p = new OstvareniProtok();
                    p.TipPlacanja = placanje.TipPlacanja;
                    p.Protok = placanje.Protok;
                    n.Placanje = p;
                }
                else if (pl != null)
                {
                    FlatRate p = new FlatRate();
                    p.TipPlacanja = pl.TipPlacanja;
                    StatickaAdresa ad = new StatickaAdresa();
                    if (pl.StatickeAdrese.Count > 1)
                    {
                        ad.FlatRate = p;
                        ad.Staticka_Adresa = pl.StatickeAdrese[0].Staticka_Adresa;
                        p.StatickeAdrese.Add(ad);

                        StatickaAdresa ad1 = new StatickaAdresa();
                        ad1.FlatRate = p;
                        ad1.Staticka_Adresa = pl.StatickeAdrese[1].Staticka_Adresa;
                        p.StatickeAdrese.Add(ad1);
                    }
                    else
                    {
                        ad.FlatRate = p;
                        ad.Staticka_Adresa = pl.StatickeAdrese[0].Staticka_Adresa;
                        p.StatickeAdrese.Add(ad);
                    }
                    n.Placanje = p;
                }

                s.Save(n);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static InternetView VratiInternet(int id)
        {
            InternetView tb = new InternetView();
            try
            {
                ISession s = DataLayer.GetSession();

                Internet t = s.Load<Internet>(id);

                tb.Id = t.Id;
                tb.Tip_usluge = t.Tip_usluge;
                tb.TipInterneta = t.TipInterneta;
                tb.FlagPrepaid = t.FlagPrepaid;
                tb.DatumPoslednjeUplate = t.DatumPoslednjeUplate;
                tb.StanjeRacuna = t.StanjeRacuna;

                Placanje pl = s.Load<Placanje>(t.Placanje.Id);

                PlacanjeView p = new PlacanjeView();

                p.Id = pl.Id;
                p.TipPlacanja = pl.TipPlacanja;
                tb.Placanje = p;

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tb;
        }

        public static void IzmeniInternet(InternetView net)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Internet t = s.Load<Internet>(net.Id);

                t.TipInterneta = net.TipInterneta;
                t.FlagPrepaid = net.FlagPrepaid;
                t.DatumPoslednjeUplate = net.DatumPoslednjeUplate;
                t.StanjeRacuna = net.StanjeRacuna;

                s.SaveOrUpdate(t);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiInternet(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Internet t = s.Load<Internet>(id);

                s.Delete(t);

                s.Flush();

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Placanje
        public static List<PlacanjeView> VratiPlacanja()
        {
            List<PlacanjeView> placanja = new List<PlacanjeView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Placanje> i = s.Query<Placanje>();
                foreach (Placanje p in i)
                {
                    if (p.TipPlacanja == "Ostvareni protok")
                    {
                        OstvareniProtok op = s.Load<OstvareniProtok>(p.Id);
                        placanja.Add(new OstvareniProtokView(op));
                    }
                    else
                    {
                        FlatRate fr=s.Load<FlatRate>(p.Id);
                        placanja.Add(new FlatRateView(fr));
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return placanja;
        }
        public static PlacanjeView VratiPlacanje(int id)
        {
            PlacanjeView tb = new PlacanjeView();
            try
            {
                ISession s = DataLayer.GetSession();

                Placanje t = s.Load<Placanje>(id);

                tb.Id = t.Id;
                tb.TipPlacanja = t.TipPlacanja;

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tb;
        }
        public static void ObrisiPlacanje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Placanje t = s.Load<Placanje>(id);

                s.Delete(t);

                s.Flush();

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Ostvareni protok
        public static OstvareniProtokView VratiPlacanjeOP(int id)
        {
            OstvareniProtokView tb = new OstvareniProtokView();
            try
            {
                ISession s = DataLayer.GetSession();

                OstvareniProtok t = s.Load<OstvareniProtok>(id);

                tb.Id = t.Id;
                tb.TipPlacanja = t.TipPlacanja;
                tb.Protok = t.Protok;

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tb;
        }

        public static void IzmeniOstvareniProtok(OstvareniProtokView placanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OstvareniProtok t = s.Load<OstvareniProtok>(placanje.Id);

                t.Protok = placanje.Protok;

                s.SaveOrUpdate(t);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SacuvajOstvareniProtok(OstvareniProtokView placanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OstvareniProtok p = new OstvareniProtok();
                p.TipPlacanja = placanje.TipPlacanja;
                p.Protok = placanje.Protok;

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Flat rate
        public static FlatRateView VratiPlacanjaFR(int id)
        {
            FlatRateView tb = new FlatRateView();
            try
            {
                ISession s = DataLayer.GetSession();

                FlatRate t = s.Load<FlatRate>(id);

                tb.Id = t.Id;
                tb.TipPlacanja = t.TipPlacanja;

                StatickaAdresaView ad = new StatickaAdresaView();
                ad.Id = t.StatickeAdrese[0].Id;
                ad.FlatRate = tb;
                ad.Staticka_Adresa = t.StatickeAdrese[0].Staticka_Adresa;
                tb.StatickeAdrese.Add(ad);
                if (t.StatickeAdrese.Count > 1)
                {
                    StatickaAdresaView ad1 = new StatickaAdresaView();
                    ad1.Id = t.StatickeAdrese[1].Id;
                    ad1.FlatRate = tb;
                    ad1.Staticka_Adresa = t.StatickeAdrese[1].Staticka_Adresa;
                    tb.StatickeAdrese.Add(ad1);
                }

                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tb;
        }
        public static void IzmeniFlatRate(FlatRateView placanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FlatRate t = s.Load<FlatRate>(placanje.Id);

                if (t.StatickeAdrese.Count == 0)
                {
                    StatickaAdresa ad1 = new StatickaAdresa();
                    ad1.FlatRate = t;
                    ad1.Staticka_Adresa = placanje.StatickeAdrese[0].Staticka_Adresa;
                    t.StatickeAdrese.Add(ad1);
                }
                else
                {
                    t.StatickeAdrese[0].Staticka_Adresa = placanje.StatickeAdrese[0].Staticka_Adresa;
                }
                if (placanje.StatickeAdrese.Count > 1)
                {
                    if (t.StatickeAdrese.Count > 1)
                    {
                        t.StatickeAdrese[1].Staticka_Adresa = placanje.StatickeAdrese[1].Staticka_Adresa;
                    }
                    else
                    {
                        StatickaAdresa ad = new StatickaAdresa();
                        ad.FlatRate = t;
                        ad.Staticka_Adresa = placanje.StatickeAdrese[1].Staticka_Adresa;
                        t.StatickeAdrese.Add(ad);
                    }
                }
                else if (t.StatickeAdrese.Count > 1)
                {
                    if (placanje.StatickeAdrese.Count < 2)
                    {
                        StatickaAdresa a = s.Load<StatickaAdresa>(t.StatickeAdrese[1].Id);

                        t.StatickeAdrese.RemoveAt(1);

                        s.Delete(a);
                    }
                }

                s.SaveOrUpdate(t);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SacuvajFlatRate(FlatRateView pl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FlatRate p = new FlatRate();
                p.TipPlacanja = pl.TipPlacanja;
                StatickaAdresa ad = new StatickaAdresa();
                if (pl.StatickeAdrese.Count > 1)
                {
                    ad.FlatRate = p;
                    ad.Staticka_Adresa = pl.StatickeAdrese[0].Staticka_Adresa;
                    p.StatickeAdrese.Add(ad);

                    StatickaAdresa ad1 = new StatickaAdresa();
                    ad1.FlatRate = p;
                    ad1.Staticka_Adresa = pl.StatickeAdrese[1].Staticka_Adresa;
                    p.StatickeAdrese.Add(ad1);
                }
                else
                {
                    ad.FlatRate = p;
                    ad.Staticka_Adresa = pl.StatickeAdrese[0].Staticka_Adresa;
                    p.StatickeAdrese.Add(ad);
                }

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Broj telefona

        public static BrojTelefonaView VratiBrojTelefona(int id)
        {
            BrojTelefonaView br = new BrojTelefonaView();
            try
            {
                ISession s = DataLayer.GetSession();

                BrojTelefona tel = s.Load<BrojTelefona>(id);

                br.Id = tel.Id;
                br.Broj = tel.Broj;
                br.Potroseni_minuti = tel.Potroseni_minuti;

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return br;
        }

        public static void SacuvajBrojTelefona(BrojTelefonaView tel)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BrojTelefona br = new BrojTelefona();

                br.Id = tel.Id;
                br.Broj = tel.Broj;
                br.Potroseni_minuti = tel.Potroseni_minuti;

                s.Save(br);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void IzmeniBrojTelefona(BrojTelefonaView tel)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BrojTelefona br = s.Load<BrojTelefona>(tel.Id);

                br.Id = tel.Id;
                br.Broj = tel.Broj;
                br.Potroseni_minuti = tel.Potroseni_minuti;

                Telefonija t=s.Load<Telefonija>(tel.PripadaTelefoniji.Id);

                br.PripadaTelefoniji = t;

                s.SaveOrUpdate(br);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiBrojTelefona(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BrojTelefona tel = s.Load<BrojTelefona>(id);

                s.Delete(tel);

                s.Flush();

                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}
