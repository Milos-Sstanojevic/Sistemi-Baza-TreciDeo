using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class PlacanjeController : Controller
    {
        [HttpGet("VratiPlacanja")]
        public IActionResult VratiPlacanja()
        {
            try
            {
                IList<PlacanjeView> pl = new List<PlacanjeView>();
                pl = DataProvider.VratiPlacanja();

                return Ok(pl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiPlacanje/{id}")]
        public IActionResult VratiPlacanje(int id)
        {
            try
            {
                PlacanjeView pl = new PlacanjeView();
                pl = DataProvider.VratiPlacanje(id);

                return Ok(pl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ObrisiPlacanje/{id}")]
        public IActionResult ObrisiPlacanje(int id)
        {
            try
            {
                DataProvider.ObrisiPlacanje(id);

                return Ok("Uspesno obrisano placanje.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
