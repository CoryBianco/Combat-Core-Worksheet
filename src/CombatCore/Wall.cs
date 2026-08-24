using System;
using System.Data;
using System.IO;

namespace CombatCore
{
    public class Wall : Damageable
    {
        public Wall(float startingHealth, float armor, float percentFireResistance) : base(startingHealth, armor,
            percentFireResistance)
        {
            if (percentFireResistance > 1 || percentFireResistance < 0)
            {
                throw new SyntaxErrorException("percentFireResistance must be between 0 and 1.");
            }
        }
    }
}