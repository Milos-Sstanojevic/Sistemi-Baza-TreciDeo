using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class HubController : Controller
    {
        [HttpPut("PoveziGSNaHub/{stanica}/{hub}")]
        public IActionResult PoveziGSNaHub(long stanica, long hub)
        {
            try
            {
                DataProvider.poveziGSNaHub(stanica, hub);

                return Ok("Uspesno povezana stanica na hub");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("OdveziGSNaHub/{stanica}/{hub}")]
        public IActionResult OdveziGSNaHub(long stanica, long hub)
        {
            try
            {
                DataProvider.odveziGSSaHuba(stanica, hub);

                return Ok("Uspesno odvezana stanica sa huba");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PromeniHub")]
        public IActionResult PromeniHub([FromBody] GlavnaStanicaView glavna)
        {
            try
            {
                DataProvider.promeniGS(glavna);

                return Ok("Uspesno azuriran Hub");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
