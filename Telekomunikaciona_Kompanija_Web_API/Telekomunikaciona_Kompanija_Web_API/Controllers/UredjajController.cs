using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;

namespace Telekom_Kompanija_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UredjajController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiUredjaje")]
        public IActionResult PreuzmiUredjaje()
        {
            try
            {
                return Ok(DataProvider.vratiSveUredjaje());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DodajKomunikacioniCvor/{serBrGS}")]
        public IActionResult DodajKomunikacioniCvor([FromBody]KomunikacioniCvorView kc, [FromRoute]long serBrGS)
        {
            try
            {
                DataProvider.dodajKC(kc,serBrGS);

                return Ok("Uspesno dodat komunikacioni cvor");
            }
            catch(Exception ex) { 
            
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("DodajGlavnuStanicu/{serBrHuba}")]
        public IActionResult DodajGlavnuStanicu([FromBody]GlavnaStanicaView gs, [FromRoute]long serBrHuba)
        {
            try
            {
                DataProvider.dodajGS(gs, serBrHuba);

                return Ok("Uspesno dodata stanica");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DodajHub")]
        public IActionResult DodajHub([FromBody] GlavnaStanicaView hub)
        {
            try
            {
                DataProvider.dodajHub(hub);

                return Ok("Uspesno dodata stanica");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ObrisiUredjaj/{serBr}")]
        public IActionResult ObrisiUredjaj(long serBr)
        {
            try
            {
                DataProvider.obrisiUredjaj(serBr);

                return Ok("Uspesno obrisan uredjaj");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PreuzmiGlavneStanice")]
        public IActionResult PreuzmiGlavneStanice()
        {
            try
            {
                return Ok(DataProvider.vratiGlavneStanice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiAdreseKomCvorovaGlavneStanice/{serBr}")]
        public IActionResult VratiAdreseKomCvorovaGS(long serBr)
        {
            try
            {
                List<KomunikacioniCvorView> cvorovi=new List<KomunikacioniCvorView>();

                cvorovi = DataProvider.vratiAdreseKomCvorova(serBr);

                return Ok(cvorovi);
            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PreuzmiHubove")]
        public IActionResult PreuzmiHubove()
        {
            try
            {
                return Ok(DataProvider.vratiHubove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiHubGlavneStanice/{serBr}")]
        public IActionResult VratiHubGlavneStanice(long serBr)
        {
            try
            {
                GlavnaStanicaView gs = new GlavnaStanicaView();
                gs=DataProvider.vratiHubOdabraneStanice(serBr);

                return Ok(gs);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("VratiGlavneStaniceHuba/{serBr}")]
        public IActionResult VratiGlavneStaniceHuba(long serBr)
        {
            try
            {
                List<GlavnaStanicaView> gs = new List<GlavnaStanicaView>();
                gs = DataProvider.vratiGlavneStaniceHuba(serBr);

                return Ok(gs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("VratiGlavnuStanicuKC/{serBr}")]
        public IActionResult VratiGlavnuStanicuKC(long serBr)
        {
            try
            {
                GlavnaStanicaView gs = new GlavnaStanicaView();
                gs = DataProvider.vratiGlavnuStanicuKC(serBr);

                return Ok(gs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiKorisnikeKC/{serBr}")]
        public IActionResult VratiKorisnikeKC(long serBr)
        {
            try
            {
                List<KorisnikView> k = new List<KorisnikView>();
                k = DataProvider.vratiKorisnikeKC(serBr);

                return Ok(k);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}