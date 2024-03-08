using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ClientOld : ENetMultiplayerPeer
{
    public ClientOld()
    {
        CreateClient("127.0.0.1", 6969);

        PeerConnected += id =>
        {
            Print("Client connected to server: " + id);
        };

        PeerDisconnected += id =>
        {
            Print("Client disconnected from server: " + id);
        };
    }
}