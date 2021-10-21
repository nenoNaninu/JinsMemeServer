using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using JinsMemeServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<MessagePool>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();
app.MapControllers();

app.Map("/", async (HttpContext context, MessagePool messagePool) =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await context.Response.WriteAsync("use websocket!");
        return;
    }

    using var socket = await context.WebSockets.AcceptWebSocketAsync();

    var buffer = new WebSocketMemoryPool(16 * 1024, 4 * 1024);
    var jsonOption = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

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

        //var a = JsonSerializer.Deserialize<MemePacket>(message.Content, jsonOption);
        var str = Encoding.UTF8.GetString(message.Content);
        Debug.WriteLine($"{result.MessageType}, message length {message.Content.Length}");
        Debug.WriteLine(str);
        messagePool.Add(message);
    }
});

app.Run();