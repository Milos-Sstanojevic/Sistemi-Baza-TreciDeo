using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace Telekom_Kompanija_Web_API.Controllers
{
    public class DodatniPaketKanalaController : Controller
    {
        [HttpGet("VratiDodatnePakete/{id}")]
        public IActionResult VratiDodatnePakete(int id)
        {
            try
            {
                IList<DodatniPaketKanalaView> tel = new List<DodatniPaketKanalaView>();
                tel = DataProvider.VratiDodatnePakete(id);

                return Ok(tel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SacuvajDodatniPaket")]
        public IActionResult SacuvajDodatniPaket([FromBody] DodatniPaketKanalaView paket)
        {
            try
            {
                DataProvider.SacuvajDodatniPaket(paket);

                return Ok("Uspesno sacuvan dodatni paket kanala.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiDodatniPaket/{id}")]
        public IActionResult VratiDodatniPaket(int id)
        {
            try
            {
                DodatniPaketKanalaView paket= new DodatniPaketKanalaView();
                paket=DataProvider.VratiDodatniPaket(id);

                return Ok(paket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("IzmeniDodatniPaket")]
        public IActionResult IzmeniDodatniPaket([FromBody] DodatniPaketKanalaView paket)
        {
            try
            {
                DataProvider.IzmeniDodatniPaket(paket);

                return Ok("Uspesno izmenjen dodatni paket kanala.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ObrisiDodatniPaketKanala/{id}")]
        public IActionResult ObrisiDodatniPaketKanala(int id)
        {
            try
            {
                DataProvider.ObrisiDodatniPaketKanala(id);

                return Ok("Uspesno obrisan dodatni paket kanala.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
