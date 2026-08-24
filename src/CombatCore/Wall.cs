using System;

namespace CombatCore
{
    public sealed class Wall : Damageable
    {
        public Wall(float startingHealth, float armor, float percentFireResistance) : base(startingHealth, armor,
            percentFireResistance) {}
    }
}