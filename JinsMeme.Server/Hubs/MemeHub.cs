using JinsMeme.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace JinsMemeShard.Hubs;

public class MemeHub : Hub<IReceiver>, IHubContract
{
    public const string Path = "/MemeHub";
}