using System.Threading.Channels;

namespace JinsMemeServer.Services;

public class MessagePool
{
    private readonly Channel<Message> _channel;
    private readonly ChannelReader<Message> _channelReader;
    private readonly ChannelWriter<Message> _channelWriter;

    public bool IsRequired { get; set; }

    public MessagePool()
    {
        _channel = Channel.CreateUnbounded<Message>(new UnboundedChannelOptions { SingleReader = true, SingleWriter = false });
        _channelReader = _channel.Reader;
        _channelWriter = _channel.Writer;
    }

    public void Add(Message message)
    {
        if (IsRequired)
        {
            _channelWriter.TryWrite(message);
        }
    }
}