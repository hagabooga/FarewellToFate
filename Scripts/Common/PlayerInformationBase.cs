using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class PlayerInformationBase : Node
{
    [Export] public Dictionary<long, Player> IdToPlayer { get; protected set; } = null;

    protected Node playersNode;

    protected void AddMultiplayerSync()
    {
        playersNode = new()
        {
            Name = "Players"
        };
        MultiplayerSpawner multiplayerSpanwer = new();
        multiplayerSpanwer.AddSpawnableScene("res://Player.tscn");
        multiplayerSpanwer.SpawnPath = "../Players";

        AddChild(playersNode);
        AddChild(multiplayerSpanwer);
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReceiveUsername(string username)
    {
        IdToPlayer[Multiplayer.GetRemoteSenderId()].Username = username;
    }

}
