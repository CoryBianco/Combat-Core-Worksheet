namespace CombatCore
{
    public class Goblin: IDamageable
    {
        private float _attackStat;
        public float health { get; set; }
        public float armor { get; set; }
        public float perfecntFireResistance { get; set; }
        public bool isAlive { get; set; }

        public Goblin(float baseAttack, float baseHealth, float baseArmor, float  basePerfecntFireResistance )
        {
            _attackStat = baseAttack;
            health = baseHealth;
            armor = baseArmor;
            perfecntFireResistance = basePerfecntFireResistance;
            isAlive = true;
        }
        public float Attack()
        {
            return _attackStat;
        }

        public void TakeDamage(float amount, DamageType type, string source)
        {
            // goblin is never attacked so it takes no damage ever
        }
    }
}