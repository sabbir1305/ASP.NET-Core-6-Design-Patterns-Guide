using HandleMessageWithChainOfResponsibility;
using HandleMessageWithChainOfResponsibility.Handlers.Messages;
using HandleMessageWithChainOfResponsibility.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMessageHandler>(new AlarmTriggeredHandler(new AlarmPausedHandler(new AlarmStoppedHandler(new DailyAlarmHandler(new DefaultHandler())))));
// Add services to the container.

var app = builder.Build();


// "Menu" endpoint
app.MapGet("/", () => new[] {
    "/handle/AlarmTriggered",
    "/handle/AlarmPaused",
    "/handle/AlarmStopped",
    "/handle/Foo",
    "/handle/Bar",
    "/handle/Baz",
    "/handle/SomeUnhandledMessageName",
});

// Consumer (client) endpoint
app.MapGet("/handle/{name}", (string name, string? payload, IMessageHandler messageHandler) =>
{
    var message = new Message(name, payload);
    try
    {
        // Send the message into the chain of responsibility
        messageHandler.Handle(message);
        return $"Message '{message.Name}' handled successfully.";
    }
    catch (NotSupportedException ex)
    {
        return ex.Message;
    }
});

app.Run();
