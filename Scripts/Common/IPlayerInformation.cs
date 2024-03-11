using Godot.Collections;

namespace FarewellToFate;

public interface IPlayerInformation
{
    Dictionary<long, Player> IdToPlayer { get; }
    void ReceiveUsername(string username);
}