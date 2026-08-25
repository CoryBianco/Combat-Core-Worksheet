using System;

namespace CombatCore
{
    public abstract class Damageable: IDamageable
    {
        public float Health { get; private set; }
        public float Armor { get; private set; }
        public float PercentFireResistance { get; private set; }
        public bool IsAlive => Health > 0f;

        public Damageable(float baseHealth, float baseArmor, float basePercentFireResistance)
        {
            if (basePercentFireResistance > 1 || basePercentFireResistance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(basePercentFireResistance));
            }
            Health = baseHealth;
            Armor = baseArmor;
            PercentFireResistance = basePercentFireResistance;
        }
        

        public void TakeDamage(DamageInfo damage)
        {
            // If Damageable is not alive do not let it take more damage.
            if (!IsAlive)
            {
                return;
            }

            var mitigated = damage.Type switch
            {
                DamageType.Fire => damage.Amount * (1 - PercentFireResistance),
                DamageType.Sword => Math.Max(0, damage.Amount - Armor),
                _ => throw new ArgumentOutOfRangeException(nameof(damage.Type))
            };

            Health -= Math.Max(0, mitigated);
        }
    }
}