using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/gym")]
    public class GymEncounterController
        : ControllerBase
    {
        private readonly IGymEncounterService
            _gymEncounterService;

        public GymEncounterController(
            IGymEncounterService gymEncounterService
        )
        {
            _gymEncounterService =
                gymEncounterService;
        }

        [HttpPost("start")]
        public async Task<IActionResult>
            StartEncounter(int runId)
        {
            try
            {
                var result =
                    await _gymEncounterService
                        .StartEncounterAsync(
                            runId
                        );

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