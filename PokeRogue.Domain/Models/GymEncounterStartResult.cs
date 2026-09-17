namespace PokeRogue.Domain.Models
{
    public class GymEncounterStartResult
    {
        public string GymLeaderName { get; set; } = string.Empty;
        public BattleStartResult Battle { get; set; } = null!;
    }
}