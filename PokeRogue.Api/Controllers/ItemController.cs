using Microsoft.AspNetCore.Mvc;
using PokeRogue.Application.Interfaces;

namespace PokeRogue.Api.Controllers
{
    [ApiController]
    [Route("api/runs/{runId}/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemEventService _itemEventService;
        private readonly IRunItemRepository _runItemRepository;

        public ItemController(
            IItemEventService itemEventService,
            IRunItemRepository runItemRepository
        )
        {
            _itemEventService = itemEventService;
            _runItemRepository = runItemRepository;
        }

        [HttpGet("options")]
        public async Task<IActionResult> GetOptions(
            int runId
        )
        {
            try
            {
                var options =
                    await _itemEventService
                        .GetItemOptionsAsync(runId);

                return Ok(options);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{itemId}")]
        public async Task<IActionResult> ChooseItem(
            int runId,
            int itemId
        )
        {
            try
            {
                var item =
                    await _itemEventService
                        .ChooseItemAsync(
                            runId,
                            itemId
                        );

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInventory(
            int runId
        )
        {
            var inventory =
                await _runItemRepository
                    .GetInventoryAsync(runId);

            return Ok(inventory);
        }
    }
}