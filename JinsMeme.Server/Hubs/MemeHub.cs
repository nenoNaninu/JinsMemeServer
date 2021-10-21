using Microsoft.AspNetCore.SignalR;
using JinsMeme.Shared.Hubs;

namespace JinsMemeShard.Hubs;

public class MemeHub : Hub<IReceiver>, IHubContract
{
    public const string Path = "/MemeHub";
}
