// See https://aka.ms/new-console-template for more information

using CombatCore;

var bus = new EventBus();

var wall = new Wall(10f, 0f, 0f);
var goblin = new Goblin(2f, 2f, 10f, 10f, 0f);

bus.Subscribe<DamageDealtEvent>((e) => Console.WriteLine(e.Amount));

while (wall.IsAlive)
{
    var damage = goblin.Attack(DamageType.Sword);
    var damageDealt = wall.TakeDamage(new DamageInfo { Type = DamageType.Sword, Amount = damage, Source = "something" });
    bus.Publish<DamageDealtEvent>(new DamageDealtEvent { Amount = damageDealt, Target = wall, Type = DamageType.Sword});
}
