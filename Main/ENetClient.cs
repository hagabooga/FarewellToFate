using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ENetClient : ENetMultiplayerPeer
{
    public ENetClient(LobbyModel lobbyModel)
    {
        CreateClient(lobbyModel.IpAddress, ENetServer.Port);

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