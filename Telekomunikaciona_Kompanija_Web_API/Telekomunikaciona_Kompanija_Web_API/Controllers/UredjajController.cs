using Microsoft.AspNetCore.Mvc;
using Telekomunikaciona_Kompanija_NHibernate;

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
                return new JsonResult(DTOmanagerM.vratiSveUredjaje());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}