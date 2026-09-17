namespace PokeRogue.Application.Interfaces
{
    public interface IPokemonCenterService
    {
        Task HealAsync(int runId);
    }
}