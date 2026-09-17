using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/pokemon-center")]
    public class PokemonCenterController : ControllerBase
    {
        private readonly IPokemonCenterService _pokemonCenterService;

        public PokemonCenterController(
            IPokemonCenterService pokemonCenterService
        )
        {
            _pokemonCenterService = pokemonCenterService;
        }

        [HttpPost("heal")]
        public async Task<IActionResult> Heal(int runId)
        {
            try
            {
                await _pokemonCenterService.HealAsync(runId);

                return Ok(new
                {
                    Message = "All Pokémon have been fully healed."
                });
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}