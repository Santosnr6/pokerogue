using PokeRogue.Application.Interfaces;
using PokeRogue.Application.Models;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Services
{
    public class RunMapService : IRunMapService
    {
        private readonly ICityMapFactory _cityMapFactory;
        private readonly IMapGeneratorService _mapGeneratorService;
        private readonly IRunMapRepository _runMapRepository;

        public RunMapService(
            ICityMapFactory cityMapFactory,
            IMapGeneratorService mapGeneratorService,
            IRunMapRepository runMapRepository)
        {
            _cityMapFactory = cityMapFactory;
            _mapGeneratorService = mapGeneratorService;
            _runMapRepository = runMapRepository;
        }

        public GeneratedMap CreateRunMap(int runId, int cityNumber)
        {
            MapLayout layout =
                _cityMapFactory.CreateCityMap(cityNumber);

            List<RunNode> runNodes =
                _mapGeneratorService.GenerateMap(
                    runId,
                    layout.Nodes
                );

            return new GeneratedMap
            {
                RunNodes = runNodes,
                Connections = layout.Connections
            };
        }

        public async Task<GeneratedMap?> GetRunMapAsync(int runId)
        {
            return await _runMapRepository.GetRunMapAsync(runId);
        }
    }
}