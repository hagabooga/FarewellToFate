using Godot;

namespace FarewellToFate;

public partial class PlayerInformation(ENetClient client, ILoginView view) : Node
{
    public override void _Ready()
    {
        client.PeerConnected += id =>
        {
            Fast.CreateForgetGDTaskWithFrameDelay(async () =>
            {
                this.RpcServer(nameof(Server.PlayerInformation.ReturnUsername), view.Username);
            });
        };
    }
}
