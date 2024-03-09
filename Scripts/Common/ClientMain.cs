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

        RegisterSingleton<PlayerInformation>();


        RegisterPackedSceneInstantiation<ChatBoxModel>("res://Scripts/Common/ChatBoxModel.tscn");
        RegisterPackedSceneInstantiation<ILoginView>("res://Scripts/Client/LoginView.tscn");


        container.Verify();

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(AddRegisteredNodes);
        });
    }
}
