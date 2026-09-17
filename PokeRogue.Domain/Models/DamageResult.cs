namespace PokeRogue.Domain.Models
{
    public class DamageResult
    {
        public int Damage { get; set; }
        public bool IsCritical { get; set; }
        public double TypeMultiplier { get; set; }
    }
}