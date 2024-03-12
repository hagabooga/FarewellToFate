using System.Net;
using Godot;

namespace FarewellToFate;

public partial class ClientMain : AbstractMain
{
    [ExplicitChild] public SoccerFieldTest SoccerFieldTest { get; }

    public LobbyModel LobbyModel { get; set; }


    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        ENetClient eNetClient = new(LobbyModel);
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetClient;
        container.RegisterInstance(eNetClient);

        RegisterNodeInstance(LobbyModel);



        RegisterSingleton<HotkeyInputs>();
        RegisterSingleton<IPlayerInformation, PlayerInformationClient>();
        RegisterSingleton<ChatBoxClientPresenter>();
        RegisterSingleton<ChatBoxNet>();


        container.RegisterInstance(SoccerFieldTest);
        RegisterSingleton<PlayerSpawner>();


        RegisterPackedSceneInstantiation<IChatBoxView>("res://ChatBox/ChatBoxView.tscn");
        RegisterPackedSceneInstantiation<ILoginView>("res://Login/LoginView.tscn");


        VerifyAndAddNodesAndStartAsync();
    }
}
