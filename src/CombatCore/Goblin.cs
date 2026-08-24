namespace CombatCore
{
    public sealed class Goblin: Damageable
    {
        public float SwordAttackStat { get; private set; }
        public float FireAttackStat { get; private set; }

        public Goblin(float baseSwordAttack, float baseFireAttack, float baseHealth, float baseArmor, float  basePercentFireResistance ) : base(baseHealth, baseArmor, basePercentFireResistance)
        {
            SwordAttackStat = baseSwordAttack;
            FireAttackStat = baseFireAttack;
        }

        public float Attack(DamageType damageType)
        {
            if (damageType == DamageType.Sword)
            {
                return SwordAttackStat;
            } else if (damageType == DamageType.Fire)
            {
                return FireAttackStat;
            }

            return 0;
        }
    }
}