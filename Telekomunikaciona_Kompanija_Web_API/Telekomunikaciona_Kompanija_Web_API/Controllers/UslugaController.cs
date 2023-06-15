using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class UslugaController : Controller
    {
        [HttpGet]
        [Route("PreuzmiUslugu")]
        public IActionResult PreuzmiUslugu([FromRoute]int id)
        {
            try
            {
                return Ok(DataProvider.vratiUslugu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("PreuzmiUsluge")]
        public IActionResult PreuzmiUsluge()
        {
            try
            {
                return Ok(DataProvider.vratiUsluge());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("OtkaziUsluguKorisniku/{idUsluge}/{jmbg}")]
        public IActionResult OtkaziUsluguKorisniku(int idUsluge,string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.otkaziUsluguKorisniku(idUsluge, jmbg);

                return Ok("Uspesno otkazana usluga");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DodeliUsluguKorisniku/{idUsluge}/{jmbg}")]
        public IActionResult DodeliUsluguKorisniku(int idUsluge, string jmbg)
        {
            try
            {
                if (jmbg.Length != 13)
                {
                    return BadRequest("JMBG mora da bude duzine 13");
                }

                DataProvider.dodeliUsluguKorisniku(idUsluge, jmbg);

                return Ok("Uspesno otkazana usluga");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
