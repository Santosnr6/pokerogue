namespace PokeRogue.Blazor.Models
{
    public class MapNodeDto
    {
        public int Id { get; set; }
        public int CityNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsFixedEvent { get; set; }
        public bool IsStartNode { get; set; }
    }
}