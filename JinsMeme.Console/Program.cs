using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JinsMeme.Shared.Hubs;
using Microsoft.AspNetCore.SignalR.Client;
using TypedSignalR.Client;

Console.WriteLine("Hello, World!");

var connection = new HubConnectionBuilder()
     .WithUrl("https://localhost:5001/MemeHub")
     .Build();

connection.Register<IReceiver>(new Receiver());
await connection.StartAsync();
Console.WriteLine("Started");

await Exit.WaitAsync();

Console.ReadLine();

Console.WriteLine("End");

class Receiver : IReceiver
{
    public Task ReceiveMessageAsync(byte[] message)
    {
        var str = Encoding.UTF8.GetString(message);
        Console.WriteLine(str);
        return Task.CompletedTask;
    }
}

public static class Exit
{
    public static Task WaitAsync()
    {
        var tcs = new TaskCompletionSource();
        Console.CancelKeyPress += (sender, e) =>
        {
            //e.Cancel = true;
            tcs.SetResult();
        };
        return tcs.Task;
    }

    public static void Wait()
    {
        using var manualResetEventSlim = new ManualResetEventSlim();
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            manualResetEventSlim.Set();
        };
        manualResetEventSlim.Wait();
    }
}