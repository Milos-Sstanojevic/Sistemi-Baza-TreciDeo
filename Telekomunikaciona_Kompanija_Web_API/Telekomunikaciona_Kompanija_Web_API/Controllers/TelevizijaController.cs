using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class TelevizijaController : Controller
    {
        [HttpGet("VratiTelevizije")]
        public IActionResult VratiTelevizije()
        {
            try
            {
                IList<TelevizijaView> tel=new List<TelevizijaView> ();
                tel=DataProvider.VratiTelevizije();

                return Ok(tel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("SacuvajTeleviziju")]
        public IActionResult SacuvajTeleviziju([FromBody]TelevizijaView tel)
        {
            try
            {
                DataProvider.SacuvajTeleviziju(tel);

                return Ok("Uspreno sacuvana televizija.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiTeleviziju/{tel}")]
        public IActionResult VratiTeleviziju(int tel)
        {
            try
            {
                TelefonijaView telefonija = new TelefonijaView();
                DataProvider.VratiTeleviziju(tel);

                return Ok(telefonija);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("IzmeniTeleviziju")]
        public IActionResult IzmeniTeleviziju([FromBody] TelevizijaView tel)
        {
            try
            {
                DataProvider.IzmeniTeleviziju(tel);

                return Ok("Uspeno azurirana televizija.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("ObrisiTeleviziju/{tel}")]
        public IActionResult ObrisiTeleviziju(int tel)
        {
            try
            {
                DataProvider.ObrisiTeleviziju(tel);

                return Ok("Uspeno obrisana televizija.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
