using Microsoft.AspNetCore.Mvc;

namespace ToCatchAGremlin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Chargecontroller : ControllerBase
    {
        IChargeService _cService;

        public Chargecontroller(IChargeService cService)
        {
            _cService = cService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChargeCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _cService.AddCharge(model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error");
        }
    }
}