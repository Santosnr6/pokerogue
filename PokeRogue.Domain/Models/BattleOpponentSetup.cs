namespace PokeRogue.Domain.Models
{
    public class BattleOpponentSetup
    {
        public int PokemonSpeciesId { get; set; }
        public int Level { get; set; }
        public int AttackStage { get; set; } = 1;
        public int PartyPosition { get; set; }
    }
}