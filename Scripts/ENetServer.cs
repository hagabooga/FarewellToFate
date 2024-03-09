using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ENetServer : ENetMultiplayerPeer
{
    private const int Port = 6969;

    public ENetServer()
    {
        CreateServer(Port);
        Print($"Server - Server started on port: {Port}");

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