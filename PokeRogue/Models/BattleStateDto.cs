namespace PokeRogue.Blazor.Models
{
    public class BattleStateDto
    {
        public int BattleId { get; set; }

        public string Status { get; set; } = string.Empty;

        public bool IsPlayerTurn { get; set; }

        public BattlePokemonDto PlayerPokemon { get; set; } = new();

        public BattlePokemonDto OpponentPokemon { get; set; } = new();

        public List<BattlePokemonDto> Party { get; set; } = new();

        public int OpponentPokemonRemaining { get; set; }
    }

    public class BattlePokemonDto
    {
        public int? RunPokemonId { get; set; }

        public int PokemonSpeciesId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }

        public int CurrentHp { get; set; }

        public int MaxHp { get; set; }

        public bool IsActive { get; set; }

        public bool IsFainted { get; set; }
    }
}