using Microsoft.AspNetCore.Mvc;
using NetCoreApiPostgreSQL.Data.Repositories;
using NetCoreApiPostgreSQL.Model;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamController : Controller
    {
        private readonly IIceRepository _iceRepository;
        public IceCreamController(IIceRepository iceRepository)
        {
            _iceRepository = iceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIceCreams() {
            return Ok(await _iceRepository.GetAllFlavors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlavorDetails(int id)
        {
            return Ok(await _iceRepository.GetFlavor(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIceCream([FromBody] IceCream ice)
        {
            if (ice == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _iceRepository.InsertFlavor(ice);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIceCream([FromBody] IceCream ice)
        {
            if (ice == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iceRepository.UpdateFlavor(ice);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIceCream(int id)
        {
            await _iceRepository.DeleteFlavor(new IceCream { Id = id});

            return NoContent();
        }
    }
}
