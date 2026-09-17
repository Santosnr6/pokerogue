namespace PokeRogue.Blazor.Models
{
    public class BattleStartDto
    {
        public int BattleId { get; set; }
        public string PlayerPokemonName { get; set; } = string.Empty;
        public int PlayerPokemonLevel { get; set; }
        public int PlayerCurrentHp { get; set; }
        public int PlayerMaxHp { get; set; }
        public string OpponentPokemonName { get; set; } = string.Empty;
        public int OpponentPokemonLevel { get; set; }
        public int OpponentCurrentHp { get; set; }
        public int OpponentMaxHp { get; set; }
        public bool PlayerAttacksFirst { get; set; }
    }
}