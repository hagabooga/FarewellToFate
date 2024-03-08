using System.Collections.Generic;
using Godot;
using static Godot.GD;
using Fractural.Tasks;
namespace FarewellToFate;

public partial class Lobby : ExplicitNode
{
    [Export] PackedScene playerPs;

    [ExplicitChild] public LineEdit NameLineEdit { get; }
    [ExplicitChild] public LineEdit IpAddressLineEdit { get; }
    [ExplicitChild] public LineEdit MessageLineEdit { get; }
    [ExplicitChild] public LineEdit DebugLineEdit1 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit2 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit3 { get; }
    [ExplicitChild] public Button CreateServerButton { get; }
    [ExplicitChild] public Button JoinServerButton { get; }
    [ExplicitChild] public Node Players { get; }

    readonly Dictionary<long, Player> idToPlayer = [];

    public override void _Ready()
    {
        base._Ready();

        MessageLineEdit.TextSubmitted += text =>
        {
            MessageLineEdit.Text = "";
        };

        CreateServerButton.Pressed += () =>
        {
            DebugLineEdit1.Text = DebugLineEdit1.Name = "Server";
            Multiplayer.MultiplayerPeer = new Server();
            Multiplayer.MultiplayerPeer.PeerConnected += id =>
            {
                var player = playerPs.Instantiate<Player>();
                Players.AddChild(player, true);
                player.Name = id.ToString();
                player.Id = id;
                idToPlayer[id] = player;
            };
        };

        JoinServerButton.Pressed += () =>
        {
            DebugLineEdit1.Text = DebugLineEdit1.Name = "Client";
            Multiplayer.MultiplayerPeer = new Client();
            Multiplayer.MultiplayerPeer.PeerConnected += id =>
            {
                GDTask.Create(async () =>
                {
                    await GDTask.Yield();
                    RpcId(1, nameof(ReceiveUsername), NameLineEdit.Text);
                }).Forget();
            };
        };
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ReceiveUsername(string username)
    {
        idToPlayer[Multiplayer.GetRemoteSenderId()].Username = username;
    }
}

