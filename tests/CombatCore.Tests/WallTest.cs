namespace CombatCore.Tests;

public class WallTest
{
    [Fact]
    public void Test1()
    {
        var wall = new Wall(5f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.False(wall.IsAlive());
    }
    [Fact]
    public void Test2()
    {
        var wall = new Wall(20f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.True(wall.IsAlive());
    }
    
    [Fact]
    public void Test3()
    {
        var wall = new Wall(10f, 0f, .05f);
        
        wall.TakeDamage(10f, DamageType.Sword, "something");

        Assert.False(wall.IsAlive());
    }
}
