using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs")]
    public class RunController : ControllerBase
    {
        private readonly IRunService _runService;
        private readonly IRunMapService _runMapService;
        private readonly IPokemonService _pokemonService;

        public RunController(
            IRunService runService,
            IRunMapService runMapService,
            IPokemonService pokemonService)
        {
            _runService = runService;
            _runMapService = runMapService;
            _pokemonService = pokemonService;
        }

        [HttpPost]
        public async Task<IActionResult> StartNewRun()
        {
            var run = await _runService.StartNewAsync();
            return Ok(run);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRun(int id)
        {
            var run = await _runService.GetRunAsync(id);

            if (run == null)
            {
                return NotFound();
            }

            return Ok(run);
        }

        [HttpGet("{id}/map")]
        public async Task<IActionResult> GetRunMap(int id)
        {
            var map = await _runMapService.GetRunMapAsync(id);

            if (map == null)
            {
                return NotFound();
            }

            return Ok(map);
        }

        [HttpPost("{id}/move/{targetNodeId}")]
        public async Task<IActionResult> MoveToNode(
            int id,
            int targetNodeId
        )
        {
            try
            {
                var result = await _runService.MoveToNodeAsync(
                    id,
                    targetNodeId
                );

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}/starters")]
        public async Task<IActionResult> GetStarters(int id)
        {
            var run = await _runService.GetRunAsync(id);

            if (run == null)
            {
                return NotFound();
            }

            var starters = await _pokemonService.GetStartersAsync();

            return Ok(starters);
        }

        [HttpPost("{id}/starter/{pokemonSpeciesId}")]
        public async Task<IActionResult> ChooseStarter(
            int id,
            int pokemonSpeciesId
        )
        {
            try
            {
                var pokemon = await _runService.ChooseStarterAsync(
                    id,
                    pokemonSpeciesId
                );

                if (pokemon == null)
                {
                    return NotFound("Run was not found.");
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
