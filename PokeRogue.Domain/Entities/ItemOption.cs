namespace PokeRogue.Domain.Entities
{
    public class ItemOption
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public int MapNodeId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}