using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class PokemonCenterService : IPokemonCenterService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IRunPokemonRepository _runPokemonRepository;

        public PokemonCenterService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            IRunPokemonRepository runPokemonRepository
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _runPokemonRepository = runPokemonRepository;
        }

        public async Task HealAsync(int runId)
        {
            var run = await _runRepository.GetByIdAsync(runId);

            if (run == null)
            {
                throw new InvalidOperationException(
                    "Run was not found."
                );
            }

            var runNode =
                await _runMapRepository.GetRunNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            if (runNode == null ||
                runNode.Type != NodeEventType.PokemonCenter)
            {
                throw new InvalidOperationException(
                    "The current node is not a Pokémon Center."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Pokémon Center event has already been completed."
                );
            }

            var pokemon =
                await _runPokemonRepository.GetByRunIdAsync(runId);

            foreach (var runPokemon in pokemon)
            {
                runPokemon.CurrentHp =
                    PokemonStatCalculator.CalculateHp(
                        runPokemon.PokemonSpecies,
                        runPokemon.Level
                    );
            }

            await _runPokemonRepository.SaveChangesAsync();

            await _runMapRepository.MarkCompletedAsync(
                runId,
                run.CurrentNodeId
            );
        }
    }
}