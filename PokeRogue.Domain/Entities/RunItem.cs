using System.Text.Json.Serialization;

namespace PokeRogue.Domain.Entities
{
    public class RunItem
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        [JsonIgnore]
        public Run Run { get; set; } = null!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int Quantity { get; set; }
    }
}