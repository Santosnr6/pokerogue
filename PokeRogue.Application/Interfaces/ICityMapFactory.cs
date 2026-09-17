using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ICityMapFactory
    {
        MapLayout CreateCityMap(int cityNumber);
    }
}