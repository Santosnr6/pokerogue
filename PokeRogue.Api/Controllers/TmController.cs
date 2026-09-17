using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/tm")]
    public class TmController : ControllerBase
    {
        private readonly ITmEventService _tmEventService;

        public TmController(
            ITmEventService tmEventService
        )
        {
            _tmEventService = tmEventService;
        }

        [HttpPost("{runPokemonId}")]
        public async Task<IActionResult> UseTM(
            int runId,
            int runPokemonId
        )
        {
            try
            {
                await _tmEventService.UpgradePokemonAttackAsync(
                    runId,
                    runPokemonId
                );

                return Ok();
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(
                    exception.Message
                );
            }
        }
    }
}