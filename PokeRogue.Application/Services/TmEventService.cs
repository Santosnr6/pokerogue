using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Enums;

namespace PokeRogue.Application.Services
{
    public class TmEventService : ITmEventService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IRunPokemonRepository _runPokemonRepository;

        public TmEventService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            IRunPokemonRepository runPokemonRepository
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _runPokemonRepository = runPokemonRepository;
        }

        public async Task UpgradePokemonAttackAsync(
            int runId,
            int runPokemonId
        )
        {
            var run =
                await _runRepository.GetByIdAsync(runId);

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
                runNode.Type != NodeEventType.TM)
            {
                throw new InvalidOperationException(
                    "The current node is not a TM event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This TM event has already been completed."
                );
            }

            var pokemon =
                await _runPokemonRepository.GetByIdAsync(
                    runPokemonId
                );

            if (pokemon == null ||
                pokemon.RunId != runId)
            {
                throw new InvalidOperationException(
                    "That Pokémon does not belong to this run."
                );
            }

            if (pokemon.AttackStage >= 3)
            {
                throw new InvalidOperationException(
                    "This Pokémon's attack is already fully upgraded."
                );
            }

            pokemon.AttackStage++;

            await _runPokemonRepository.SaveChangesAsync();

            await _runMapRepository.MarkCompletedAsync(
                runId,
                run.CurrentNodeId
            );
        }
    }
}