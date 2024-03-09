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

        container.Verify();

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(AddRegisteredNodes);
        });

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(x =>
            {
                if (x.GetType().IsAssignableFrom(typeof(IAsyncStartable)))
                {
                    Print(x.GetType().Name);
                    var genericMethod = SimpleInjectorUtility.GetInstance1Type0Args.MakeGenericMethod(x);
                    var node = (IAsyncStartable)genericMethod.Invoke(container, []);
                    node.StartAsync();
                }
            });
        });

    }
}