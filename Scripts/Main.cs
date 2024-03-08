using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class Main : AbstractMain
{
    [Export] PackedScene lobbyPs;

    [ExplicitChild] public LobbyView LobbyView { get; }

    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        RegisterSingleton<HotkeyInputs>();
        RegisterNode(LobbyView);

        container.Verify();


        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(AddRegisteredNodes);
        });
    }

}
