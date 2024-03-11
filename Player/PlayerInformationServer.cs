using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class PlayerInformationServer(ENetServer server) : PlayerInformationBase
{
    PackedScene playerPs;

    public override void _Ready()
    {
        base._Ready();
        IdToPlayer = [];

        AddMultiplayerSync();

        playerPs = GD.Load<PackedScene>(PlayerScenePath);

        server.PeerConnected += id =>
        {
            var player = playerPs.Instantiate<Player>();
            player.Name = id.ToString();
            playersNode.AddChild(player, true);
            player.Id = id;
            IdToPlayer[id] = player;
            player.SetMultiplayerAuthority((int)id);
        };

        server.PeerDisconnected += id =>
        {
            var player = IdToPlayer[id];
            IdToPlayer.Remove(id);
            player.QueueFree();
        };
    }



}
