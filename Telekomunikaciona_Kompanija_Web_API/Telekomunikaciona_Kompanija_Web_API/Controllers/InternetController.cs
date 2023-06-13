using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class InternetController : Controller
    {
        [HttpGet("VratiInternete")]
        public IActionResult VratiInternete()
        {
            try
            {
                IList<InternetView> tel = new List<InternetView>();
                tel = DataProvider.VratiInternete();

                return Ok(tel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("SacuvajInternet")]
        public IActionResult SacuvajInternet([FromBody] InternetView net, OstvareniProtokView placanje, FlatRateView pl)
        {
            try
            {
                DataProvider.SacuvajInternet(net, placanje, pl);

                return Ok("Uspesno dodat internet.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiInternet/{id}")]
        public IActionResult VratiInternet(int id)
        {
            try
            {
                InternetView net=new InternetView();
                net=DataProvider.VratiInternet(id);

                return Ok(net);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniInternet")]
        public IActionResult IzmeniInternet([FromBody]InternetView net)
        {
            try
            {
                DataProvider.IzmeniInternet(net);

                return Ok("Uspesno izmenjen internet.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ObrisiInternet/{id}")]
        public IActionResult ObrisiInternet(int id)
        {
            try
            {
                DataProvider.ObrisiInternet(id);

                return Ok("Uspesno obrisan internet.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
