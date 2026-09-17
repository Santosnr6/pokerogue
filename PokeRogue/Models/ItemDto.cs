namespace PokeRogue.Blazor.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EffectType { get; set; } = string.Empty;
        public string Trigger { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public int Value { get; set; }
        public string? TargetPokemonType { get; set; }
        public bool IsConsumable { get; set; }
    }
}