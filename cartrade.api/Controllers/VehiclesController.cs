using Microsoft.AspNetCore.Mvc;

namespace cartrade.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        [HttpGet]
        public ActionResult ListAllVehicles()
        {
            return Ok("Funkar");
        }
    }
}
