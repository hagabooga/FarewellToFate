using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class PlayerInformationBase : Node, IPlayerInformation
{
    public const string PlayerScenePath = "res://Player/Player.tscn";

    [Export] public Dictionary<long, Player> IdToPlayer { get; protected set; } = null;

    protected Node playersNode;

    protected void AddMultiplayerSync()
    {
        playersNode = new()
        {
            Name = "Players"
        };
        MultiplayerSpawner multiplayerSpanwer = new();
        multiplayerSpanwer.AddSpawnableScene(PlayerScenePath);
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
