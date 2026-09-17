using System.Net.Http.Json;
using PokeRogue.Blazor.Models;

namespace PokeRogue.Blazor.Services
{
    public class EventApiService
    {
        private readonly HttpClient _httpClient;

        public EventApiService(
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<List<ItemDto>> GetItemOptionsAsync(
            int runId
        )
        {
            var response =
                await _httpClient.GetAsync(
                    $"api/runs/{runId}/items/options"
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not load item options: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<List<ItemDto>>()
                ?? new List<ItemDto>();
        }

        public async Task ChooseItemAsync(
            int runId,
            int itemId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/items/{itemId}",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not choose item: {message}"
                );
            }
        }

        public async Task<List<PokemonDto>> GetCatchOptionsAsync(
            int runId
        )
        {
            var response =
                await _httpClient.GetAsync(
                    $"api/runs/{runId}/catch/options"
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not load catch options: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<List<PokemonDto>>()
                ?? new List<PokemonDto>();
        }

        public async Task CatchPokemonAsync(
            int runId,
            int pokemonSpeciesId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/catch/{pokemonSpeciesId}",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not catch Pokémon: {message}"
                );
            }
        }

        public async Task UseTmAsync(
            int runId,
            int runPokemonId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/tm/{runPokemonId}",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not use TM: {message}"
                );
            }
        }
    }
}