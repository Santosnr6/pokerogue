using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/map")]
    public class MapController : ControllerBase
    {
        private readonly IRunMapService _runMapService;

        public MapController(IRunMapService runMapService)
        {
            _runMapService = runMapService;
        }

        [HttpGet("test")]
        public IActionResult GetTestMap()
        {
            var map = _runMapService.CreateRunMap(
                runId: 1,
                cityNumber: 1
            );

            return Ok(map);
        }
    }
}