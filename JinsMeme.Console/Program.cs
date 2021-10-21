// See https://aka.ms/new-console-template for more information
using System.Text;
using TypedSignalR.Client;
using JinsMeme.Shared.Hubs;
using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");

var connection = new HubConnectionBuilder()
     .WithUrl("https://localhost:5001/MemeHub")
     .Build();


connection.Register<IReceiver>(new Receiver());
await connection.StartAsync();

Console.ReadLine();

class Receiver : IReceiver
{
    public Task ReceiveMessageAsync(byte[] message)
    {
        var str = Encoding.UTF8.GetString(message);
        Console.WriteLine(str);
        return Task.CompletedTask;
    }
}