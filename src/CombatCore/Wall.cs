using System;
using System.Data;
using System.IO;

namespace CombatCore
{
    public class Wall : IDamageable
    {
        private float _health;
        private float _armor;
        private float _percentFireResistance;
        private bool _isAlive;

        public bool IsAlive()
        {
            return this._isAlive;
        }

        public Wall(float startingHealth, float armor, float percentFireResistance)
        {
            if (percentFireResistance > 1 || percentFireResistance < 0)
            {
                throw new SyntaxErrorException("percentFireResistance must be between 0 and 1.");
            }
            this._health = startingHealth;
            this._armor = armor;
            this._percentFireResistance = percentFireResistance;
            this._isAlive = true;
        }

        public void TakeDamage(float amount, DamageType type, string source)
        {
            if (!this._isAlive) return;
            var calcedDamage = 0f;

            if (type == DamageType.Fire)
            {
                calcedDamage = amount * this._percentFireResistance;
            } else if (type == DamageType.Sword)
            {
                calcedDamage = Math.Max(0, amount - this._armor);
            }

            this._health -= calcedDamage;

            if (this._health <= 0)
            {
                Die();
            }
            
        }

        private void Die()
        {
            if (this._isAlive)
            {
                this._isAlive = false;
            }
        }
    }
}