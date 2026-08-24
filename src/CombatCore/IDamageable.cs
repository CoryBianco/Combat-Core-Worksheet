namespace CombatCore
{
    interface IDamageable
    {
        float health { get; }
        public void TakeDamage(float amount, DamageType type, string source); // Not really sure how to type the source.
    }
}