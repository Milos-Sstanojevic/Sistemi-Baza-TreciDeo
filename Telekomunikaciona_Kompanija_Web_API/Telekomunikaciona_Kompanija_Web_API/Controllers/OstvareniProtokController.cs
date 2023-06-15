using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class OstvareniProtokController : Controller
    {
        [HttpGet("VratiPlacanjeOP/{id}")]
        public IActionResult VratiPlacanjeOP(int id)
        {
            try
            {
                OstvareniProtokView pl = new OstvareniProtokView();
                pl = DataProvider.VratiPlacanjeOP(id);

                return Ok(pl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniOstvareniProtok")]
        public IActionResult IzmeniOstvareniProtok([FromBody] OstvareniProtokView protok)
        {
            try
            {
                DataProvider.IzmeniOstvareniProtok(protok);

                return Ok("Uspesno izmenjeno placanje.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SacuvajOstvareniProtok")]
        public IActionResult SacuvajOstvareniProtok([FromBody] OstvareniProtokView protok)
        {
            try
            {
                DataProvider.SacuvajOstvareniProtok(protok);

                return Ok("Uspesno dodat internet.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
