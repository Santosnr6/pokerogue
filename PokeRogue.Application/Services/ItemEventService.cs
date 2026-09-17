using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;

namespace PokeRogue.Application.Services
{
    public class ItemEventService : IItemEventService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IItemOptionRepository _itemOptionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IRunItemRepository _runItemRepository;

        public ItemEventService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            IItemOptionRepository itemOptionRepository,
            IItemRepository itemRepository,
            IRunItemRepository runItemRepository
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _itemOptionRepository = itemOptionRepository;
            _itemRepository = itemRepository;
            _runItemRepository = runItemRepository;
        }

        public async Task<List<Item>> GetItemOptionsAsync(
            int runId
        )
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
                runNode.Type != NodeEventType.Item)
            {
                throw new InvalidOperationException(
                    "The current node is not an Item event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Item event has already been completed."
                );
            }

            var existingOptions =
                await _itemOptionRepository
                    .GetByRunAndNodeAsync(
                        runId,
                        run.CurrentNodeId
                    );

            if (existingOptions.Count > 0)
            {
                return existingOptions
                    .Select(option => option.Item)
                    .ToList();
            }

            var items =
                await _itemRepository.GetAllAsync();

            var availableItems = items
                .Where(item =>
                    item.EffectType !=
                    ItemEffectType.AttackUpgrade
                )
                .ToList();

            if (availableItems.Count < 3)
            {
                throw new InvalidOperationException(
                    "Not enough items are available."
                );
            }

            var selectedItems = availableItems
                .OrderBy(_ => Random.Shared.Next())
                .Take(3)
                .ToList();

            var options = selectedItems
                .Select(item => new ItemOption
                {
                    RunId = runId,
                    MapNodeId = run.CurrentNodeId,
                    ItemId = item.Id
                })
                .ToList();

            await _itemOptionRepository.SaveAsync(options);

            return selectedItems;
        }

        public async Task<Item?> ChooseItemAsync(
            int runId,
            int itemId
        )
        {
            var run = await _runRepository.GetByIdAsync(runId);

            if (run == null)
            {
                return null;
            }

            var options =
                await _itemOptionRepository
                    .GetByRunAndNodeAsync(
                        runId,
                        run.CurrentNodeId
                    );

            var selectedOption =
                options.FirstOrDefault(option =>
                    option.ItemId == itemId
                );

            if (selectedOption == null)
            {
                throw new InvalidOperationException(
                    "That item is not one of the available choices."
                );
            }

            await _runItemRepository.AddItemAsync(
                runId,
                itemId
            );

            await _itemOptionRepository
                .DeleteByRunAndNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            await _runMapRepository.MarkCompletedAsync(
                runId,
                run.CurrentNodeId
            );

            return selectedOption.Item;
        }
    }
}