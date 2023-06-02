using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;

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
                return new JsonResult(DataProvider.vratiSveUredjaje());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}