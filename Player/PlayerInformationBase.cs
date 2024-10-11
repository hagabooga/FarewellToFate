using System.Diagnostics;
using Godot;
using Godot.Collections;
using static Godot.GD;
namespace FarewellToFate;

public partial class PlayerInformationBase : Node, IPlayerInformation
{
    public const string PlayerScenePath = "res://Player/Player.tscn";

    public event MultiplayerSpawner.SpawnedEventHandler Spawned
    {
        add => PlayerSpawner.Spawned += value;
        remove => PlayerSpawner.Spawned -= value;
    }

    [Export] public Dictionary<long, Player> IdToPlayer { get; protected set; } = [];

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
        var id = Multiplayer.GetRemoteSenderId();
        IdToPlayer[id].Username = username;
        if (IsMultiplayerAuthority())
        {
            Print($"I am the server. Sending username {id} / {username} to all clients.");
            this.RpcClients(nameof(ReceiveUsername), id, username);
        }
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReceiveUsername(long id, string username)
    {
        IdToPlayer[id].Username = username;
    }
}
