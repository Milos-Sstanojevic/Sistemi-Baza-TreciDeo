using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class TelefonController : Controller
    {
        [HttpGet]
        [Route("PreuzmiTelefone")]
        public IActionResult PreuzmiTelefone()
        {
            try
            {
                return Ok(DataProvider.vratiTelefone());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PromeniTelefon/{novi}/{stari}")]
        public IActionResult PromeniTelefon(string novi, string stari)
        {
            try
            {
                if (novi.Length != 10)
                {
                    return BadRequest("Novi broj mora da ima 10 cifara ukljucujuci i 0");
                }

                DataProvider.promeniTelefon(novi, stari);

                return Ok("Uspesno promenjen telefon");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("KreirajTelefonIDodeliKorisniku/{telefon}/{jmbg}")]
        public IActionResult KreirajTelefonIDodeliKorisniku(string telefon, string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.kreirajTelefonIDodeliKorisniku(telefon, jmbg);

                return Ok("Uspesno kreiran telefon");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
