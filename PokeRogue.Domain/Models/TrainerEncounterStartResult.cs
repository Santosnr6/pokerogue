namespace PokeRogue.Domain.Models
{
    public class TrainerEncounterStartResult
    {
        public string TrainerName { get; set; } = string.Empty;
        public BattleStartResult Battle { get; set; } = null!;
    }
}