using PokeRogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunRepository
    {
        Task<Run> CreateAsync(Run run);
        Task<Run?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
