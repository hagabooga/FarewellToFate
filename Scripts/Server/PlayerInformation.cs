using Godot;
using Godot.Collections;

namespace FarewellToFate.Server;

public partial class PlayerInformation(ENetServer server) : PlayerInformationBase
{

    PackedScene playerPs;

    public override void _Ready()
    {
        base._Ready();
        IdToPlayer = [];

        AddMultiplayerSync();

        playerPs = GD.Load<PackedScene>("res://Player.tscn");

        server.PeerConnected += id =>
        {
            var player = playerPs.Instantiate<Player>();
            player.Name = id.ToString();
            playersNode.AddChild(player, true);
            player.Id = id;
            IdToPlayer[id] = player;
        };
    }



}
