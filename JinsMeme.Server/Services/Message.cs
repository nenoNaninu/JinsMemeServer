using System.Net.WebSockets;

namespace JinsMemeShard.Services;

public class Message
{
    public byte[] Content { get; }
    public WebSocketMessageType MessageType { get; }

    public Message(byte[] content, WebSocketMessageType messageType)
    {
        Content = content;
        MessageType = messageType;
    }
}