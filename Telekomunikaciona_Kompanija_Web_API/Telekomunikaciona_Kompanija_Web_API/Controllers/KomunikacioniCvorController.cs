using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class KomunikacioniCvorController : Controller
    {
        [HttpPut("DodajGlavnuStanicuKomCvoru/{cvor}/{stanica}")]
        public IActionResult DodajGlavnuStanicuKomCvoru(long cvor,long stanica)
        {
            try
            {
                DataProvider.dodajKCGS(cvor, stanica);

                return Ok("Uspesno dodata glavna stanica komunikacionom cvoru");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AzurirajKomCvor")]
        public IActionResult AzurirajKomCvor([FromBody]KomunikacioniCvorView cvor)
        {
            try
            {
                DataProvider.promeniKC(cvor);

                return Ok("Uspesno promenjen cvor");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PromeniStanicuKomCvora/{serBrGs}/{serBrKc}")]
        public IActionResult PromeniStanicuKomCvora(long serBrGs,long serBrKc)
        {
            try
            {
                DataProvider.promeniGSKCa(serBrGs, serBrKc);

                return Ok("Uspesno promenjena glavna stanica komunikacionog cvora");
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UkloniKorisnikaKomCvora/{jmbg}/{serBr}")]
        public IActionResult UkloniKorisnikaKomCvora(string jmbg, long serBr)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.ukloniKorisnikaKCa(jmbg, serBr);

                return Ok("Uspesno uklonjen korisnik Komunikacionog cvora");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DodajKorisnikaKomCvora/{jmbg}/{serBr}")]
        public IActionResult DodajKorisnikaKomCvora(string jmbg, long serBr)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.dodajKorisnikaKCu(jmbg, serBr);

                return Ok("Uspesno dodat korisnik Komunikacionog cvora");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PreuzmiKomunikacioneCvorove")]
        public IActionResult PreuzmiKomunikacioneCvorove()
        {
            try
            {
                List<KomunikacioniCvorView> cvorovi = new List<KomunikacioniCvorView>();

                cvorovi = DataProvider.vratiKomCvorove();

                return Ok(cvorovi);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
