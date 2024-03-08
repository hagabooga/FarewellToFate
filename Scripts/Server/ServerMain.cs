using Godot;

namespace FarewellToFate.Server;


public partial class PlayersModel : Node
{

}

public partial class ServerMain : AbstractMain
{
    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterPackedSceneInstantiation<ChatBoxModel>("res://Scripts/Common/ChatBoxModel.tscn");


        container.Verify();

        typesRegisteredAsNode.ForEach(AddRegisteredNodes);
    }
}