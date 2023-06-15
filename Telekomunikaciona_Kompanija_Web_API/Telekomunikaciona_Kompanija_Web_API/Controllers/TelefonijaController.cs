using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class TelefonijaController : Controller
    {
        [HttpPost("SacuvajTelefoniju")]
        public IActionResult SacuvajTelefoniju([FromBody]TelefonijaView tel)
        {
            try
            {
                DataProvider.SacuvajTelefoniju(tel);

                return Ok("Uspesno sacuvali telefoniju.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("VratiTelefoniju/{tel}")]
        public IActionResult VratiTelefoniju(int tel)
        {
            try
            {
                TelefonijaView te=new TelefonijaView();
                te=DataProvider.VratiTelefoniju(tel);

                return Ok(te);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("IzmeniTelefoniju")]
        public IActionResult IzmeniTelefoniju([FromBody]TelefonijaView tel)
        {
            try
            {
                DataProvider.IzmeniTelefoniju(tel);

                return Ok("Uspesno azurirana telefonija.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("ObrisiTelefoniju/{tel}")]
        public IActionResult ObrisiTelefoniju(int tel)
        {
            try
            {
                DataProvider.ObrisiTelefoniju(tel);

                return Ok("Uspesno obrisana telefonija.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
