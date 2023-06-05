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
    }
}
