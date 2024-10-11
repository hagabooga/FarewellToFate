using Fractural.Tasks;
using static Godot.GD;
namespace FarewellToFate;

public partial class PlayerInformationClient(
    ENetClient client,
    LobbyModel view
) : PlayerInformationBase, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
        AddMultiplayerSync();

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            this.RpcServer(nameof(ReceiveUsername), view.Username);
        });

    }

    public async GDTask StartAsync()
    {
        // Print("PlayerInformation StartAsync");
        // await GDTask.Yield();
        // Print("PlayerInformation StartAsync After Yield");
        // this.RpcServer(nameof(ReceiveUsername), view.Username);
    }
}