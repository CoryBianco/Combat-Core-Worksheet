using System;

namespace CombatCore
{

    public enum DamageType
    {
        Fire,
        Sword
    }

    public class Unit
    {
        private float health;
        private float armor;
        private float fireResistance;
        private bool alive;

        public Unit(float startingHealth = 100f, float startingArmor = 10f, float startingFireResistance = 20f)
        {
            health = startingHealth;
            armor = startingArmor;
            fireResistance = startingFireResistance;
            alive = true;
        }

        public float Health()
        {
            return health;
        }

        public bool TakeDamage(float damage, DamageType type, string origin)
        {
            if (!alive) return false;
            if (type == DamageType.Fire)
            {
                health -= damage * (1 - 1 / fireResistance);
            }

            if (type == DamageType.Sword)
            {
                health -= Math.Min(Math.Abs(damage - armor), 0);
            }

            if (health <= 0)
            {
                Die();
            }

            return true;

        }

        public void Die()
        {
            alive = false;
        }

    }
}
