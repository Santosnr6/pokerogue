using System.Net.Http.Json;
using PokeRogue.Blazor.Models;

namespace PokeRogue.Blazor.Services
{
    public class BattleApiService
    {
        private readonly HttpClient _httpClient;

        public BattleApiService(
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<BattleStartDto>
            StartRandomEncounterAsync(int runId)
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/encounter/start",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not start encounter: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<BattleStartDto>()
                ?? throw new InvalidOperationException(
                    "Battle could not be created."
                );
        }

        public async Task<TrainerEncounterStartDto>
            StartTrainerEncounterAsync(int runId)
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/trainer/start",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not start trainer encounter: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<TrainerEncounterStartDto>()
                ?? throw new InvalidOperationException(
                    "Trainer encounter could not be created."
                );
        }

        public async Task<GymEncounterStartDto>
            StartGymEncounterAsync(int runId)
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/runs/{runId}/gym/start",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not start gym encounter: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<GymEncounterStartDto>()
                ?? throw new InvalidOperationException(
                    "Gym encounter could not be created."
                );
        }

        public async Task<BattleStateDto>
            GetBattleStateAsync(int battleId)
        {
            var response =
                await _httpClient.GetAsync(
                    $"api/battles/{battleId}"
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not load battle: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<BattleStateDto>()
                ?? throw new InvalidOperationException(
                    "Battle state could not be loaded."
                );
        }

        public async Task<BattleAttackResultDto>
            AttackAsync(int battleId)
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/battles/{battleId}/next",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Attack failed: {message}"
                );
            }

            return await response.Content
                .ReadFromJsonAsync<BattleAttackResultDto>()
                ?? throw new InvalidOperationException(
                    "Attack result could not be loaded."
                );
        }

        public async Task SwitchPokemonAsync(
            int battleId,
            int runPokemonId
        )
        {
            var response =
                await _httpClient.PostAsync(
                    $"api/battles/{battleId}/switch/{runPokemonId}",
                    null
                );

            if (!response.IsSuccessStatusCode)
            {
                var message =
                    await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Could not switch Pokémon: {message}"
                );
            }
        }
    }
}