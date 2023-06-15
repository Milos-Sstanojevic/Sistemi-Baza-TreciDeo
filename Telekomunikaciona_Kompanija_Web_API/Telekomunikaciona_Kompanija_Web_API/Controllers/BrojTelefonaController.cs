using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class BrojTelefonaController : Controller
    {
        [HttpGet("VratiBrojTelefona/{id}")]
        public IActionResult VratiBrojTelefona(int id)
        {
            try
            {
                BrojTelefonaView broj = new BrojTelefonaView();
                broj = DataProvider.VratiBrojTelefona(id);

                return Ok(broj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SacuvajBrojTelefona")]
        public IActionResult SacuvajBrojTelefona([FromBody] BrojTelefonaView broj)
        {
            try
            {
                DataProvider.SacuvajBrojTelefona(broj);

                return Ok("Uspesno sacuvan broj telefona.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("IzmeniBrojTelefona")]
        public IActionResult IzmeniBrojTelefona([FromBody] BrojTelefonaView broj)
        {
            try
            {
                DataProvider.IzmeniBrojTelefona(broj);

                return Ok("Uspesno izmenjen broj telefona.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ObrisiBrojTelefona/{id}")]
        public IActionResult ObrisiBrojTelefona(int id)
        {
            try
            {
                DataProvider.ObrisiBrojTelefona(id);

                return Ok("Uspesno obrisan broj telefona.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
