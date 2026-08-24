namespace CombatCore.Tests;

public class WallTest
{
    [Fact]
    public void TakeDamage_WhenDamageExceedsHealth_Kills()
    {
        var wall = new Wall(5f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.False(wall.IsAlive());
    }
    [Fact]
    public void TakeDamage_WhenDamageIsSurvivable_LeavesAlive()
    {
        var wall = new Wall(20f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.True(wall.IsAlive());
    }
    
    [Fact]
    public void TakeDamage_WhenDamageExactlyEqualsHealth_Kills()
    {
        var wall = new Wall(10f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.False(wall.IsAlive());
    }
    
    [Fact]
    public void TakeDamage_DamageLowersHealth()
    {
        var wall = new Wall(20f, 0f, .05f);
        wall.TakeDamage(10f, DamageType.Sword, "something");
        Assert.Equal(10f, wall.health);
    }

    [Fact]
    public void TakeDamage_FireDamageLowersHealth()
    {
        var wall = new Wall(20f, 0f, .5f);
        wall.TakeDamage(10f, DamageType.Fire, "something");
        
        Assert.Equal(15f, wall.health);
    }
}
