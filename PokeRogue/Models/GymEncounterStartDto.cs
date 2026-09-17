namespace PokeRogue.Blazor.Models
{
    public class GymEncounterStartDto
    {
        public string GymLeaderName { get; set; } = string.Empty;
        public BattleStartDto Battle { get; set; } = new();
    }
}