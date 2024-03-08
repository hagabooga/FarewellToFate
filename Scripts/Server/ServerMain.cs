using Godot;

namespace FarewellToFate.Server;

public partial class ServerMain : AbstractMain
{
    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterPackedSceneInstantiation<ChatBoxModel>("res://Scripts/Common/ChatBoxModel.tscn");
        RegisterSingleton<Players>();


        container.Verify();

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(AddRegisteredNodes);
        });
    }
}