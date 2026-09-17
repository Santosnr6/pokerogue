using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/catch")]
    public class CatchController : ControllerBase
    {
        private readonly ICatchService _catchService;

        public CatchController(ICatchService catchService)
        {
            _catchService = catchService;
        }

        [HttpGet("options")]
        public async Task<IActionResult> GetOptions(int runId)
        {
            try
            {
                var options =
                    await _catchService.GetCatchOptionsAsync(runId);

                return Ok(options);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{pokemonSpeciesId}")]
        public async Task<IActionResult> ChoosePokemon(
            int runId,
            int pokemonSpeciesId
        )
        {
            try
            {
                var pokemon =
                    await _catchService.ChoosePokemonAsync(
                        runId,
                        pokemonSpeciesId
                    );

                if (pokemon == null)
                {
                    return NotFound();
                }

                return Ok(pokemon);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}