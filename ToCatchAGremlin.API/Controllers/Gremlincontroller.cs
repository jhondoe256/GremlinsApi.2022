using Microsoft.AspNetCore.Mvc;

namespace ToCatchAGremlin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Gremlincontroller : ControllerBase
    {
        private IGermlinService _gService;

        public Gremlincontroller(IGermlinService gService)
        {
            _gService = gService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gremlins = await _gService.GetGremlins();
            return Ok(gremlins);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gremlin = await _gService.GetGremlinDetail(id);
            return Ok(gremlin);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GremlinCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _gService.AddGremlin(model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error");
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Put(int id, GremlinEdit model)
        {
            if (id != model.Id || !ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _gService.UpdateGremlin(id, model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error");
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _gService.DeleteGremlin(id))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error");
        }
    }
}