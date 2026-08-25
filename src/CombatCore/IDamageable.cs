namespace CombatCore
{
    public readonly struct DamageInfo
    {
        public float Amount { get; init; }
        public DamageType Type { get; init; }
        public string Source { get; init; }
    }
    public interface IDamageable
    {
        float Health { get; }
        public bool IsAlive { get; }
        public float TakeDamage(DamageInfo damage);
    }
}