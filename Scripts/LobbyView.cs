using Godot;
using static Godot.GD;
using Fractural.Tasks;
using System;
using Godot.Collections;
namespace FarewellToFate;

public partial class LobbyView : ExplicitNode
{
    [Export] PackedScene playerPs, serverPs, clientPs;

    [ExplicitChild] public LineEdit NameLineEdit { get; }
    [ExplicitChild] public LineEdit IpAddressLineEdit { get; }
    [ExplicitChild] public LineEdit MessageLineEdit { get; }
    [ExplicitChild] public LineEdit DebugLineEdit1 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit2 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit3 { get; }
    [ExplicitChild] public Button CreateServerButton { get; }
    [ExplicitChild] public Button JoinServerButton { get; }
    [ExplicitChild] public Node Players { get; }

    [Export] public Dictionary<long, Player> IdToPlayer { get; private set; } = [];

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
            Multiplayer.MultiplayerPeer = new OLdServer();
            Multiplayer.MultiplayerPeer.PeerConnected += id =>
            {
                var player = playerPs.Instantiate<Player>();
                player.Name = id.ToString();
                Players.AddChild(player, true);
                player.Id = id;
                IdToPlayer[id] = player;
            };
        };

        JoinServerButton.Pressed += () =>
        {
            DebugLineEdit1.Text = DebugLineEdit1.Name = "Client";
            Multiplayer.MultiplayerPeer = new ClientOld();
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
        IdToPlayer[Multiplayer.GetRemoteSenderId()].Username = username;
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void SendChatMessage(string text)
    {
        throw new NotImplementedException();
    }

}

