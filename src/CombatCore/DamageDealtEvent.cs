namespace CombatCore
{
    public struct DamageDealtEvent
    {
        public IDamageable Target { get; init; }
        public float Amount { get; init; }
        public DamageType Type { get; init; }
    }
}