namespace PokeRogue.Domain.Entities
{
    public class BattleOpponentPokemon
    {
        public int Id { get; set; }
        public int BattleId { get; set; }
        public Battle Battle { get; set; } = null!;
        public int PokemonSpeciesId { get; set; }
        public PokemonSpecies PokemonSpecies { get; set; } = null!;
        public int Level { get; set; }
        public int CurrentHp { get; set; }
        public int AttackStage { get; set; }
        public int PartyPosition { get; set; }
    }
}