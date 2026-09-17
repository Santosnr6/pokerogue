using PokeRogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Application.Interfaces
{
    public interface IMapGeneratorService
    {
        List<RunNode> GenerateMap(
            int runId,
            List<MapNode> mapNodes
        );
    }
}
