using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using JinsMeme.Shared.Hubs;
using JinsMemeShard.Hubs;
using JinsMemeShard.Services;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<MessagePool>();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();
app.MapControllers();
app.MapHub<MemeHub>(MemeHub.Path);



app.Map("/", async (HttpContext httpContext, IHubContext<MemeHub, IReceiver> hubContext) =>
{
    if (!httpContext.WebSockets.IsWebSocketRequest)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsync("use websocket!");
        return;
    }

    using var socket = await httpContext.WebSockets.AcceptWebSocketAsync();

    var buffer = new WebSocketMemoryPool(16 * 1024, 4 * 1024);
    //var jsonOption = new JsonSerializerOptions()
    //{
    //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //};

    while (socket.State == WebSocketState.Open)
    {
        var result = await socket.ReceiveAsync(buffer.SliceFromOffset(), CancellationToken.None);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            break;
        }

        buffer.Offset += result.Count;

        if (!result.EndOfMessage)
        {
            continue;
        }

        var message = new Message(buffer.ToArray(), result.MessageType);

        buffer.Offset = 0;

#if DEBUG
        var str = Encoding.UTF8.GetString(message.Content);
        Debug.WriteLine($"{result.MessageType}, message length {message.Content.Length}");
        Debug.WriteLine(str);
#endif

        await hubContext.Clients.All.ReceiveMessageAsync(message.Content);
    }
});

app.Run();