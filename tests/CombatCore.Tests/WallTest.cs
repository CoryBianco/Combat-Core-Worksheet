namespace CombatCore.Tests;

public class WallTest
{
    
    [Fact]
    public void Wall_MustHaveValidFireResistance()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Wall(5f, 0f, -1f));
    }
    [Fact]
    public void TakeDamage_WhenDamageExceedsHealth_Kills()
    {
        var wall = new Wall(5f, 0f, .05f);

        wall.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Sword, Source = "something" });

        Assert.False(wall.IsAlive);
    }
    [Fact]
    public void TakeDamage_WhenDamageIsSurvivable_LeavesAlive()
    {
        var wall = new Wall(20f, 0f, .05f);

        wall.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Sword, Source = "something" });

        Assert.True(wall.IsAlive);
    }

    [Fact]
    public void TakeDamage_WhenDamageExactlyEqualsHealth_Kills()
    {
        var wall = new Wall(10f, 0f, .05f);

        wall.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Sword, Source = "something" });

        Assert.False(wall.IsAlive);
    }

    [Fact]
    public void TakeDamage_DamageLowersHealth()
    {
        var wall = new Wall(20f, 0f, .05f);
        wall.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Sword, Source = "something" });
        Assert.Equal(10f, wall.Health, 3);
    }

    [Fact]
    public void TakeDamage_FireDamageLowersHealth()
    {
        var wall = new Wall(20f, 0f, .5f);
        wall.TakeDamage(new DamageInfo { Amount = 10f, Type = DamageType.Fire, Source = "something" });
        
        Assert.Equal(15f, wall.Health, 3);
    }
}
