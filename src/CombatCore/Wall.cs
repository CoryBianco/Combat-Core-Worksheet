using System;

namespace CombatCore
{
    public class Wall : IDamageable
    {
        private float health;
        private float armor;
        private float fireResistance; // fire resistance must be > 1
        private bool isAlive = true;

        public Wall(float startingHealth, float armor, float fireResistance)
        {
            this.health = startingHealth;
            this.armor = armor;
            this.fireResistance = fireResistance;
            isAlive = true;
        }

        public void TakeDamage(float amount, DamageType type, string source)
        {
            if (!isAlive) return;
            var calcedDamage = 0f;

            if (type == DamageType.Fire)
            {
                calcedDamage = amount * (1 - (1 / fireResistance));
            } else if (type == DamageType.Sword)
            {
                calcedDamage = Math.Max(0, amount - armor);
            }

            this.health -= calcedDamage;

            if (health <= 0)
            {
                Die();
            }
            
        }

        private void Die()
        {
            if (isAlive)
            {
                isAlive = false;
            }
        }
    }
}