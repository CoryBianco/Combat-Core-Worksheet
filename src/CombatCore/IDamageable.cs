namespace CombatCore
{
    interface IDamageable
    {
        public void TakeDamage(float amount, DamageType type, string source); // Not really sure how to type the source.
    }
}