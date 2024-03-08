using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class Server : ENetMultiplayerPeer
{
    public Server()
    {
        CreateServer(6969);

        PeerConnected += id =>
        {
            Print("Server - Client connected to server: " + id);
        };

        PeerDisconnected += id =>
        {
            Print("Server - Client disconnected from server: " + id);
        };
    }
}