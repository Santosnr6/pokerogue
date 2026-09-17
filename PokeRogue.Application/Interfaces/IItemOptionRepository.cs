using PokeRogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Application.Interfaces
{
    public interface IItemOptionRepository
    {
        Task<List<ItemOption>> GetByRunAndNodeAsync(
            int runId,
            int mapNodeId
        );
        Task SaveAsync(List<ItemOption> options);
        Task DeleteByRunAndNodeAsync(
            int runId,
            int mapNodeId
        );
    }
}
