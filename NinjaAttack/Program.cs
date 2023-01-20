using NinjaAttack;
using NinjaAttack.Contracts;
using NinjaAttack.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/mele", async (HttpContext context) =>
{
    // Create actors
    var target = new Ninja("The Unseen Mirage", new Sword(), new Shuriken());
    var ninja = new Ninja("The Blue Phantom", new Sword(), new Shuriken());

    // Execute the sequence of actions
    await Logic.ExecuteSequenceAsync(ninja, target, writeAsync: s => context.Response.WriteAsync(s));
});
app.MapGet("/mixed", async (HttpContext context) =>
{
    // Create actors
    var target = new Ninja("The Unseen Mirage", new Sword(), new Pistol());
    var ninja = new Ninja("The Blue Phantom", new Sword(), new Shuriken());
    // Execute the sequence of actions
    await Logic.ExecuteSequenceAsync(ninja, target, writeAsync: s => context.
    Response.WriteAsync(s));
});

app.MapGet("/pirate", async (HttpContext context) =>
{
    // Create actors
    var theUnseenMirage = new Ninja("The Unseen Mirage", new Sword(), new
    Pistol());
    var blackbeard = new Pirate("Blackbeard", new Kick(), new Cutlass(), new
    BoardingAxe(), new Blunderbuss());
    var barrel = new Barrel().MoveTo(20, 45);
    // Execute a sequence of actions
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintMovementAsync(theUnseenMirage.MoveTo(1, 1));
    await PrintAttackResultAsync(theUnseenMirage.Attack(blackbeard));
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintMovementAsync(theUnseenMirage.MoveTo(3, 3));
    await PrintAttackResultAsync(theUnseenMirage.Attack(blackbeard));
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintMovementAsync(theUnseenMirage.MoveTo(5, 5));
    await PrintAttackResultAsync(theUnseenMirage.Attack(blackbeard));
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintMovementAsync(theUnseenMirage.MoveTo(40, 40));
    await PrintAttackResultAsync(theUnseenMirage.Attack(blackbeard));
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintMovementAsync(theUnseenMirage.MoveTo(80, 80));
    await PrintAttackResultAsync(theUnseenMirage.Attack(blackbeard));
    await PrintAttackResultAsync(blackbeard.Attack(theUnseenMirage));
    await PrintAttackResultAsync(blackbeard.Attack(barrel));
    // Utilities
    async Task PrintAttackResultAsync(AttackResult attackResult)
    {
        if (attackResult.Succeeded)
        {
            await context.Response.WriteAsync($"{attackResult.Attacker} hits {attackResult.Target} using {attackResult.Weapon} at distance {attackResult.Distance}!{Environment.NewLine}");
        }
        else
        {
            await context.Response.WriteAsync($"{attackResult.Attacker} misses {attackResult.Target} using {attackResult.Weapon} at distance {attackResult.Distance}...{Environment.NewLine}");
        }
    }

    async Task PrintMovementAsync(IAttackable ninja)
    {
        await context.Response.WriteAsync($"{ninja.Name} moved to {ninja.Position}.{Environment.NewLine}");
    }
});
app.Run();