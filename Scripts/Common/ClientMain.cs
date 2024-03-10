using Godot;

namespace FarewellToFate;

public partial class ClientMain : AbstractMain
{
    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        ENetClient eNetClient = new();
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetClient;
        container.RegisterInstance(eNetClient);

        RegisterSingleton<HotkeyInputs>();
        RegisterSingleton<IPlayerInformation, PlayerInformation>();
        RegisterSingleton<ChatBoxClientPresenter>();
        RegisterSingleton<ChatBoxNet>();


        RegisterPackedSceneInstantiation<IChatBoxView>("res://Scripts/Client/ChatBoxView.tscn");
        RegisterPackedSceneInstantiation<ILoginView>("res://Scripts/Client/LoginView.tscn");


        VerifyAndAddNodesAndStartAsync();
    }
}
