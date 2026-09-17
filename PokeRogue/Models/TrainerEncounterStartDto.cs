namespace PokeRogue.Blazor.Models
{
    public class TrainerEncounterStartDto
    {
        public string TrainerName { get; set; } = string.Empty;
        public BattleStartDto Battle { get; set; } = new();
    }
}