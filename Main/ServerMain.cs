using Godot;
using static Godot.GD;
namespace FarewellToFate;

public partial class ServerMain : AbstractMain
{
    [ExplicitChild] public SoccerFieldTest SoccerFieldTest { get; }

    public LobbyModel LobbyModel { get; set; }

    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterSingleton<ChatBoxNet>();
        RegisterNodeInstance(LobbyModel);

        RegisterSingleton<IPlayerInformation, PlayerInformationServer>();
        ENetServer eNetServer = new();
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetServer;
        container.RegisterInstance(eNetServer);

        VerifyAndAddNodesAndStartAsync();
    }

}

