using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class GlavnaStanicaController : Controller
    {
        [HttpPut("PromeniHubGSe/{hubSerBr}/{gsSerBr}")]
        public IActionResult PromeniHubGSe(long hubSerBr,long gsSerBr)
        {
            try
            {
                DataProvider.promeniHubGSe(hubSerBr, gsSerBr);

                return Ok("Uspesno promenjen hub ove stanice");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ProglasiZaHub/{serBr}")]
        public IActionResult ProglasiZaHub(long serBr)
        {
            try
            {
                DataProvider.proglasiZaHub(serBr); 
                
                return Ok("Uspesno proglasena za Hub");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PromeniGS")]
        public IActionResult PromeniGS([FromBody]GlavnaStanicaView glavna)
        {
            try
            {
                DataProvider.promeniGS(glavna);

                return Ok("Uspesno azurirana Glavna stanica");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("PreuzmiKomCvoroveGlavneStanica/{serBr}")]
        public IActionResult PreuzmiKomCvoroveGlavneStanica(long serBr)
        {
            try
            {
                List<KomunikacioniCvorView> cvorovi = new List<KomunikacioniCvorView>();

                cvorovi = DataProvider.vratiKCvoroveGS(serBr);

                return Ok(cvorovi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
