using System;
using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class ChatBoxModel : Node
{
    public event Action ChatBoxUpdated;

    [Export] public Array<string> Messages { get; private set; } = [];

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReceiveMessage(string message)
    {
        if (Messages.Count >= 10)
        {
            Messages.RemoveAt(0);
        }
        Messages.Add(message);
        this.RpcClients(nameof(UpdateChatBox));
    }

    [Rpc(MultiplayerApi.RpcMode.Authority)]
    public void UpdateChatBox() => ChatBoxUpdated?.Invoke();


}
