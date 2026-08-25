namespace CombatCore.Tests
{
    public class GoblinTest
    {
        [Fact]
        public void Attack_SwordAttack()
        {
            var goblin = new Goblin(5f, 1f,5f, 0f, .05f);

            var damage = goblin.Attack(DamageType.Sword); 

            Assert.Equal(5f, damage, 3);
        }
        
        [Fact]
        public void Attack_FireAttack()
        {
            var goblin = new Goblin(5f, 1f,5f, 0f, .05f);

            var damage = goblin.Attack(DamageType.Fire); 

            Assert.Equal(1f, damage, 3);
        }
        
        [Fact]
        public void Goblin_MustHaveValidFireResistance()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Goblin(0f,0f,5f, 0f, -1f));
        }
        [Fact]
        public void TakeDamage_WhenDamageExceedsHealth_Kills()
        {
            var goblin = new Goblin(0f, 0f, 5f, 0f, .05f);

            goblin.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Sword, Source = "something" });

            Assert.False(goblin.IsAlive);
        }
    }
}