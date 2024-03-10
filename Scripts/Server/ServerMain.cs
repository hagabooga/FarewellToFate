using Godot;
using static Godot.GD;
namespace FarewellToFate.Server;

public partial class ServerMain : AbstractMain
{
    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterSingleton<ChatBoxNet>();
        RegisterSingleton<IPlayerInformation, PlayerInformation>();
        ENetServer eNetServer = new();
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetServer;
        container.RegisterInstance(eNetServer);

        VerifyAndAddNodesAndStartAsync();
    }

}

