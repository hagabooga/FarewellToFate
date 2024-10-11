using Godot;

namespace FarewellToFate;

public partial class LobbyModel : Node
{
    [Export] public string IpAddress { get; set; }
    [Export] public string Username { get; set; }
}
