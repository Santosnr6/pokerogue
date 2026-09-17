using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET /api/pokemon
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pokemon = await _pokemonService.GetAllAsync();

            return Ok(pokemon);
        }

        //GET /api/pokemon/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pokemon = await _pokemonService.GetByIdAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }
    }
}