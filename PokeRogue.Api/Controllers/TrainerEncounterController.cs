using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/trainer")]
    public class TrainerEncounterController
        : ControllerBase
    {
        private readonly ITrainerEncounterService
            _trainerEncounterService;

        public TrainerEncounterController(
            ITrainerEncounterService
                trainerEncounterService
        )
        {
            _trainerEncounterService =
                trainerEncounterService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartEncounter(
            int runId
        )
        {
            try
            {
                var result =
                    await _trainerEncounterService
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