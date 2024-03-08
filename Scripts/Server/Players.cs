using Godot;
using Godot.Collections;

namespace FarewellToFate.Server;

public partial class Players : Node
{
    [Export] public Dictionary<long, Player> IdToPlayer { get; private set; } = [];
}
