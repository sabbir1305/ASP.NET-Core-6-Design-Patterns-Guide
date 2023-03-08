using Mediator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapGet("/message", () =>
{
    var millerMessageWriter = new MessageWriter();
    var orazioMessageWriter = new MessageWriter();
    var miller = new ConcreteColleague("Miller", millerMessageWriter);
    var orazio = new ConcreteColleague("orazio", orazioMessageWriter);
    var mediator = new ConcreteMediator(miller, orazio);
    mediator.Send(new Message(
        from: miller,
        content: "Hey everyone!"
        ));
    mediator.Send(new Message(
from: orazio,
content: "What's up Miller?"
));
    return millerMessageWriter.Output.ToString() ;
});

app.Run();

