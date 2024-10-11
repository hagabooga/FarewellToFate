using Godot;
using Godot.Collections;

namespace FarewellToFate;

public interface IPlayerInformation
{
    event MultiplayerSpawner.SpawnedEventHandler Spawned;

    Dictionary<long, Player> IdToPlayer { get; }
    void ReceiveUsername(string username);
}