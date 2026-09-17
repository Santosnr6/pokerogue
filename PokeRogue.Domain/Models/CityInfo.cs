namespace PokeRogue.Domain.Models
{
    public class CityInfo
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int WildPokemonMinLevel { get; set; }
        public int WildPokemonMaxLevel { get; set; }
        public int TrainerPokemonMinLevel { get; set; }
        public int TrainerPokemonMaxLevel { get; set; }
        public EvolutionStageWeights CatchEvolutionWeights { get; set; } = new();
        public EvolutionStageWeights WildEvolutionWeights { get; set; } = new();
        public EvolutionStageWeights TrainerEvolutionWeights { get; set; } = new();
    }
}