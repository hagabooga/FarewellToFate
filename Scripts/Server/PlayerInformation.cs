using Godot;
using Godot.Collections;

namespace FarewellToFate.Server;

public partial class PlayerInformation(ENetServer server) : Node
{
    [Export] public Dictionary<long, Player> IdToPlayer { get; private set; } = [];

    PackedScene playerPs;

    public override void _Ready()
    {
        base._Ready();

        Node node = new()
        {
            Name = "Players"
        };
        AddChild(node);

        MultiplayerSpawner multiplayerSpawner = new();
        AddChild(multiplayerSpawner);
        multiplayerSpawner.SpawnPath = "../Players";
        multiplayerSpawner.AddSpawnableScene("res://Player.tscn");

        playerPs = GD.Load<PackedScene>("res://Player.tscn");

        server.PeerConnected += id =>
        {
            var player = playerPs.Instantiate<Player>();
            player.Name = id.ToString();
            node.AddChild(player, true);
            player.Id = id;
            IdToPlayer[id] = player;
        };
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReturnUsername(string username)
    {
        IdToPlayer[Multiplayer.GetRemoteSenderId()].Username = username;
    }

}
