using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/encounter")]
    public class RandomEncounterController
        : ControllerBase
    {
        private readonly IRandomEncounterService
            _randomEncounterService;

        public RandomEncounterController(
            IRandomEncounterService
                randomEncounterService
        )
        {
            _randomEncounterService =
                randomEncounterService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartEncounter(
            int runId
        )
        {
            try
            {
                var result =
                    await _randomEncounterService
                        .StartEncounterAsync(runId);

                return Ok(result);
            }
            catch (
                InvalidOperationException exception
            )
            {
                return BadRequest(
                    exception.Message
                );
            }
        }
    }
}