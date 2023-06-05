using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class KorisnikController : Controller
    {
        [HttpDelete("ObrisiKorisnika/{JMBG}")]
        public IActionResult ObrisiKorisnika(string JMBG)
        {
            try
            {
                if (JMBG.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.obrisiKorisnika(JMBG);

                return Ok("Uspesno obrisan korisnik");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DodajPravnoLice/{serBrKC}")]
        public IActionResult DodajPravnoLice(PravnoLiceView lice, long serBrKC)
        {
            try
            {
                DataProvider.dodajPravnoLice(lice, serBrKC);
                return Ok("Uspesno dodato pravno lice");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("DodajFizickoLice/{serBrKC}")]
        public IActionResult DodajFizickoLice(FizickoLiceView lice, long serBrKC)
        {
            try
            {
                DataProvider.dodajFizickoLice(lice, serBrKC);
                return Ok("Uspesno dodato fizicko lice");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DodajKCKorisniku/{JMBG}")]
        public IActionResult DodajKCKorisniku([FromBody] KomunikacioniCvorView kc, string JMBG)
        {
            try
            {
                DataProvider.dodajKCKorisniku(JMBG, kc);

                return Ok("Uspesno dodaj Komunikacioni Cvor korisniku");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PreuzmiKorisnike")]
        public IActionResult PreuzmiKorisnike()
        {
            try
            {
                return Ok(DataProvider.vratiSveKorisnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniFizickoLice")]
        public IActionResult IzmeniFizickoLice([FromBody] FizickoLiceView lice)
        {
            try
            {
                DataProvider.promeniKorisnikaFizickoLice(lice);

                return Ok("Uspesno promenjeno fizicko lice");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniPravnoLice")]
        public IActionResult IzmeniPravnoLice([FromBody] PravnoLiceView lice)
        {
            try
            {
                DataProvider.promeniKorisnikaPravnoLice(lice);

                return Ok("Uspesno promenjeno pravno lice");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("VratiPravnoLice/{JMBG}")]
        public IActionResult VratiPravnoLice(string JMBG)
        {
            try
            {
                if (JMBG.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                return Ok(DataProvider.vratiPravnoLice(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("VratiFizickoLice/{JMBG}")]
        public IActionResult VratiFizickoLice(string JMBG)
        {
            try
            {
                if (JMBG.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                return Ok(DataProvider.vratiFizickoLiceBasic(JMBG));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiKomCvorKorisnika/{jmbg}")]
        public IActionResult VratiKomCvorKorisnika(string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                KomunikacioniCvorView kc = new KomunikacioniCvorView();

                kc = DataProvider.vratiKCKorisnika(jmbg);

                return Ok(kc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiTelefoneKorisnika/{jmbg}")]
        public IActionResult VratiTelefoneKorsnika(string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                List<TelefonView> telefoni = new List<TelefonView>();

                telefoni = DataProvider.vratiTelefoneKorisnika(jmbg);

                return Ok(telefoni);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("VratiUslugeKorisnika/{jmbg}")]
        public IActionResult VratiUslugeKorisnika(string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                List<UslugaView> usluge=new List<UslugaView>();

                usluge=DataProvider.vratiUslugeKorisnika(jmbg); 
                
                return Ok(usluge);
            }
            catch(Exception ex) {
            
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PromeniKomunikacioniCvorKorisniku/{jmbg}/{serBr}")]
        public IActionResult PromeniKomunikacioniCvorKorisniku(string jmbg,long serBr)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.promeniKCKorisniku(jmbg,serBr);

                return Ok("Uspesno promenjen Komunikacioni cvor korisniku");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
