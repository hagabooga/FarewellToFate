using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class Main : AbstractMain
{
    [Export] PackedScene lobbyPs;

    [ExplicitChild] public LobbyView LobbyView { get; }

    public override async void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterSingleton<HotkeyInputs>();
        RegisterNode(LobbyView);

        container.Verify();


        typesRegisteredAsNode.ForEach(AddRegisteredNodes);
    }

}
