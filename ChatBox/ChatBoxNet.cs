using System;
using Godot;

namespace FarewellToFate;

public partial class ChatBoxNet(IPlayerInformation playerInformation) : Node
{
    public event Action<string> MessageReceived;

    public void SendServerMessage(string message)
    {
        this.RpcServer(nameof(ServerReceiveMessage), message);
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    void ServerReceiveMessage(string message)
    {
        // check profanity here
        this.RpcClients(nameof(ClientReceiveMessage),
            $"[{TimeOnly.FromDateTime(DateTime.Now).ToLongTimeString()}] {playerInformation.IdToPlayer[Multiplayer.GetRemoteSenderId()].Username}: {message}");
    }

    [Rpc(MultiplayerApi.RpcMode.Authority)]
    void ClientReceiveMessage(string message)
    {
        MessageReceived?.Invoke(message);
    }
}
