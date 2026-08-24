using System;

namespace CombatCore
{
    public class Damageable: IDamageable
    {
        public float Health { get; private set; }
        public float Armor { get; private set; }
        public float PercentFireResistance { get; private set; }
        public bool IsAlive => Health > 0f;

        public Damageable(float baseHealth, float baseArmor, float basePercentFireResistance)
        {
            Health = baseHealth;
            Armor = baseArmor;
            PercentFireResistance = basePercentFireResistance;
        }
        

        public void TakeDamage(DamageInfo damage)
        {
            if (damage.Type == DamageType.Fire)
            {
                Health -= damage.Amount * (1 - PercentFireResistance);
                return;
            } else if (damage.Type == DamageType.Sword)
            {
                Health -= Math.Max(0, damage.Amount - Armor);
                return;
            }
        }
    }
}