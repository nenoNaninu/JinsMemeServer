using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinsMeme.Shared.MemePackets;

namespace JinsMeme.Shared.Hubs;

public interface IReceiver
{
    Task ReceiveMessageAsync(byte[] message);
}