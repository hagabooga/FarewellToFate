using Fractural.Tasks;
using Godot;

namespace FarewellToFate;

public partial class PlayerInformation(ENetClient client, ILoginView view) : Node, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
        AddChild(new Node()
        {
            Name = "Players"
        });
        MultiplayerSpawner node = new();
        node.AddSpawnableScene("res://Player.tscn");
        AddChild(node);
        node.SpawnPath = "../Players";
    }

    public async GDTask StartAsync()
    {
        view.TextSubmitted += username =>
        {
            Fast.CreateForgetGDTaskWithFrameDelay(async () =>
            {
                this.RpcServer(nameof(Server.PlayerInformation.ReturnUsername), username);
            });
        };
    }
}