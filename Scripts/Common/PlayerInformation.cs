using Fractural.Tasks;
using static Godot.GD;
namespace FarewellToFate;

public partial class PlayerInformation
(
    ENetClient client,
    ILoginView view
) : PlayerInformationBase, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
        AddMultiplayerSync();
    }

    public async GDTask StartAsync()
    {
        Print("PlayerInformation StartAsync");
        view.TextSubmitted += username =>
        {
            this.RpcServer(nameof(ReceiveUsername), username);
        };
    }
}