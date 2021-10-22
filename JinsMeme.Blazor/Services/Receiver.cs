using JinsMeme.Shared.Hubs;
using System.Text;

namespace JinsMeme.Blazor.Services;

public class Receiver2 : IReceiver
{
    private readonly List<string> _messages;
    public Receiver2(List<string> messages)
    {
        _messages = messages;
    }
    public Task ReceiveMessageAsync(byte[] message)
    {
        var str = Encoding.UTF8.GetString(message);
        _messages.Add(str);
        return Task.CompletedTask;
    }
}
