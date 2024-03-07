using System.Collections.Generic;
using Godot;
using static Godot.GD;
using Fractural.Tasks;
namespace FarewellToFate;

public partial class Lobby : ExplicitNode
{
    [Export] PackedScene playerPs;

    [Explicit] public LineEdit NameLineEdit { get; }
    [Explicit] public LineEdit IpAddressLineEdit { get; }
    [Explicit] public LineEdit MessageLineEdit { get; }
    [Explicit] public LineEdit DebugLineEdit1 { get; }
    [Explicit] public LineEdit DebugLineEdit2 { get; }
    [Explicit] public LineEdit DebugLineEdit3 { get; }
    [Explicit] public Button CreateServerButton { get; }
    [Explicit] public Button JoinServerButton { get; }
    [Explicit] public MultiplayerSpawner PlayerSpawner { get; }
    [Explicit] public Node Players { get; }

    public override void _Ready()
    {
        base._Ready();

        MessageLineEdit.TextSubmitted += text =>
        {
            MessageLineEdit.Text = "";
        };

        CreateServerButton.Pressed += () =>
        {
            ENetMultiplayerPeer peer = new();
            peer.CreateServer(6969);
            if (peer.GetConnectionStatus() == MultiplayerPeer.ConnectionStatus.Disconnected)
            {
                OS.Alert("Failed to start multiplayer server.");
                return;
            }
            Print("Started server.");
            List<long> connectedIds = [];
            List<string> messages = new(10);
            Multiplayer.MultiplayerPeer = peer;
            peer.PeerConnected += id =>
            {
                connectedIds.Add(id);
                Print("Client connected to server: " + id);
                DebugLineEdit1.Text = $"[{string.Join(", ", connectedIds)}]";
                var player = playerPs.Instantiate<Player>();

                Players.AddChild(player);


                GDTask.Create(async () =>
                {
                    await GDTask.Yield();
                    player.Id = id;
                    player.Username = NameLineEdit.Text;
                });

            };
            peer.PeerDisconnected += id =>
            {
                connectedIds.Remove(id);
                Print("Client disconnected from server: " + id);
                DebugLineEdit1.Text = $"[{connectedIds.Join(", ")}]";
            };

        };

        JoinServerButton.Pressed += () =>
        {
            ENetMultiplayerPeer peer = new();
            peer.CreateClient(IpAddressLineEdit.Text, 6969);
            if (peer.GetConnectionStatus() == MultiplayerPeer.ConnectionStatus.Disconnected)
            {
                OS.Alert("Failed to start multiplayer client.");
                return;
            }
            Multiplayer.MultiplayerPeer = peer;
            peer.PeerConnected += id =>
            {
                Print("Connected to server: " + id);
            };
        };

    }


    // public override void _Process(double delta)
    // {
    //     MultiplayerSynchronizer
    // }

}

