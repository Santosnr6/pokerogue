using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Enums
{
    public enum ItemTrigger
    {
        Passive,
        OnAttack,
        OnHit,
        OnAttacked,
        EndOfTurn,
        OnFaint,
        OnUse
    }
}
