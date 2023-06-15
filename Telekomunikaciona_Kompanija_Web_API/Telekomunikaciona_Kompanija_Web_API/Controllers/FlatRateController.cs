using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class FlatRateController : Controller
    {
        [HttpGet("VratiPlacanjaFR/{id}")]
        public IActionResult VratiPlacanjaFR(int id)
        {
            try
            {
                FlatRateView pl = new FlatRateView();
                pl = DataProvider.VratiPlacanjaFR(id);

                return Ok(pl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniFlatRate")]
        public IActionResult IzmeniFlatRate([FromBody] FlatRateView fl)
        {
            try
            {
                DataProvider.IzmeniFlatRate(fl);

                return Ok("Uspesno izmenjen FlatRate.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SacuvajFlatRate")]
        public IActionResult SacuvajFlatRate([FromBody] FlatRateView fl)
        {
            try
            {
                DataProvider.SacuvajFlatRate(fl);

                return Ok("Uspesno dodat FlatRate.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
