using System.Net.Http.Json;
using PokeRogue.Blazor.Models;

namespace PokeRogue.Blazor.Services
{
    public class RunApiService
    {
        private readonly HttpClient _httpClient;

        public RunApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RunDto?> StartRunAsync()
        {
            var response = await _httpClient.PostAsync(
                "api/runs",
                null
            );

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<RunDto>();
        }

        public async Task<RunDto?> GetRunAsync(int runId)
        {
            return await _httpClient
                .GetFromJsonAsync<RunDto>(
                    $"api/runs/{runId}"
                );
        }

        public async Task<List<PokemonDto>> GetStartersAsync(
            int runId
        )
        {
            return await _httpClient
                .GetFromJsonAsync<List<PokemonDto>>(
                    $"api/runs/{runId}/starters"
                )
                ?? new List<PokemonDto>();
        }

        public async Task ChooseStarterAsync(
            int runId,
            int pokemonSpeciesId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/starter/{pokemonSpeciesId}",
                    null
                );

            response.EnsureSuccessStatusCode();
        }

        public async Task<RunMapDto?> GetRunMapAsync(
            int runId
        )
        {
            return await _httpClient
                .GetFromJsonAsync<RunMapDto>(
                    $"api/runs/{runId}/map"
                );
        }

        public async Task MoveToNodeAsync(
            int runId,
            int targetNodeId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/move/{targetNodeId}",
                    null
                );

            response.EnsureSuccessStatusCode();
        }
    }
}