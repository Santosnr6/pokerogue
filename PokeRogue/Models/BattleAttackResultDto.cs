namespace PokeRogue.Blazor.Models
{
    public class BattleAttackResultDto
    {
        public string AttackerName { get; set; } = string.Empty;
        public string DefenderName { get; set; } = string.Empty;
        public string AttackName { get; set; } = string.Empty;
        public int Damage { get; set; }
        public bool IsCritical { get; set; }
        public double TypeMultiplier { get; set; }
        public int PreviousHp { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public bool Fainted { get; set; }
        public int? NewActivePlayerPokemonId { get; set; }
        public string? NewActivePlayerPokemonName { get; set; }
        public int? NewActiveOpponentPokemonId { get; set; }
        public string? NewActiveOpponentPokemonName { get; set; }
        public string BattleStatus { get; set; } = string.Empty;
    }
}