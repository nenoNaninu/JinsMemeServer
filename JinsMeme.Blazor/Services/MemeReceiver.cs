using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using JinsMeme.Shared.Hubs;

namespace JinsMeme.Blazor.Services;

public class MemeReceiver : IReceiver, IObservable<Unit>
{
    private readonly List<string> _messages;
    private readonly Subject<Unit> _subject = new();

    public MemeReceiver(List<string> messages)
    {
        _messages = messages;
    }

    public Task ReceiveMessageAsync(byte[] message)
    {
        var str = Encoding.UTF8.GetString(message);
        _messages.Add(str);
        _subject.OnNext(Unit.Default);
        return Task.CompletedTask;
    }

    public IDisposable Subscribe(IObserver<Unit> observer) => _subject.Subscribe(observer);
}