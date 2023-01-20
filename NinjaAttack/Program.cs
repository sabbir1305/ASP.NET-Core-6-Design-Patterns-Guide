using NinjaAttack;
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
app.Run();