using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Services
{
    public static class CatchRandomizer
    {
        public static List<PokemonSpecies> PickWeightedPokemon(
            List<CatchZone> catchZone,
            int amount
        )
        {
            if (catchZone.Count < amount)
            {
                throw new InvalidOperationException(
                    "Not enough Pokémon are available in this catch zone."
                );
            }

            var availableZones = catchZone.ToList();
            var selectedPokemon = new List<PokemonSpecies>();

            for (int i = 0; i < amount; i++)
            {
                CatchZone selectedZone =
                    PickWeightedRandom(availableZones);

                selectedPokemon.Add(
                    selectedZone.PokemonSpecies
                );

                availableZones.Remove(selectedZone);
            }

            return selectedPokemon;
        }

        private static CatchZone PickWeightedRandom(
            List<CatchZone> zones
        )
        {
            int totalWeight =
                zones.Sum(zone => zone.Weight);

            int roll =
                Random.Shared.Next(1, totalWeight + 1);

            int cumulativeWeight = 0;

            foreach (var zone in zones)
            {
                cumulativeWeight += zone.Weight;

                if (roll <= cumulativeWeight)
                {
                    return zone;
                }
            }

            throw new InvalidOperationException(
                "Could not select a Pokémon."
            );
        }
    }
}