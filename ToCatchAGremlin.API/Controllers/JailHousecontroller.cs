using Microsoft.AspNetCore.Mvc;

namespace ToCatchAGremlin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JailHousecontroller : ControllerBase
    {
        //  WE NEED OUR DEPENDENCY
        IJailHouseService _jService;

        public JailHousecontroller(IJailHouseService jService)
        {
            _jService = jService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJailHouses()
        {
            var jHouses = await _jService.GetJailHouses();
            return Ok(jHouses);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jHouse = await _jService.GetJailHouseDetail(id);
            return Ok(jHouse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(JaliHouseCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _jService.AddJailHouse(model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Put(int id, JailHouseEdit model)
        {
            if (!ModelState.IsValid || id != model.Id)
            {
                return BadRequest(ModelState);
            }

            if (await _jService.UpdateJailHouse(id, model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _jService.DeleteJailHouse(id))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}
