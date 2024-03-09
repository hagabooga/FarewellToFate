using Godot;
using static Godot.GD;
namespace FarewellToFate.Server;

public partial class ServerMain : AbstractMain
{
    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterPackedSceneInstantiation<ChatBoxModel>("res://Scripts/Common/ChatBoxModel.tscn");
        RegisterSingleton<PlayerInformation>();
        ENetServer eNetServer = new();
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetServer;
        container.RegisterInstance(eNetServer);

        VerifyAndAddNodesAndStartAsync();
    }

}