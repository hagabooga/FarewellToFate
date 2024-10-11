using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class PlayerInformationBase : Node, IPlayerInformation
{
    public const string PlayerScenePath = "res://Player/Player.tscn";

    public event MultiplayerSpawner.SpawnedEventHandler Spawned
    {
        add => PlayerSpawner.Spawned += value;
        remove => PlayerSpawner.Spawned -= value;
    }

    [Export] public Dictionary<long, Player> IdToPlayer { get; protected set; } = null;

    public MultiplayerSpawner PlayerSpawner { get; private set; } = new();

    protected Node playersNode;


    protected void AddMultiplayerSync()
    {
        playersNode = new()
        {
            Name = "Players"
        };
        PlayerSpawner.AddSpawnableScene(PlayerScenePath);
        PlayerSpawner.SpawnPath = "../Players";
        PlayerSpawner.Name = "PlayerSpawner";

        AddChild(playersNode);
        AddChild(PlayerSpawner);
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReceiveUsername(string username)
    {
        IdToPlayer[Multiplayer.GetRemoteSenderId()].Username = username;
    }
}
