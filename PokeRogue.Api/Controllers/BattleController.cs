using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/battles")]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService _battleService;

        public BattleController(
            IBattleService battleService
        )
        {
            _battleService = battleService;
        }

        [HttpPost("{battleId}/next")]
        public async Task<IActionResult> NextAttack(
            int battleId
        )
        {
            try
            {
                var result =
                    await _battleService.ExecuteNextAttackAsync(
                        battleId
                    );

                return Ok(result);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{battleId}/switch/{runPokemonId}")]
        public async Task<IActionResult> SwitchPokemon(
            int battleId,
            int runPokemonId
        )
        {
            try
            {
                var result =
                    await _battleService.SwitchPokemonAsync(
                        battleId,
                        runPokemonId
                    );

                return Ok(result);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{battleId}")]
        public async Task<IActionResult> GetBattleState(
            int battleId
        )
        {
            try
            {
                var result =
                    await _battleService.GetBattleStateAsync(
                        battleId
                    );

                return Ok(result);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}