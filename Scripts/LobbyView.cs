using Godot;
using static Godot.GD;
using Fractural.Tasks;
using System;
using Godot.Collections;
namespace FarewellToFate;

public partial class LobbyView : ExplicitNode
{
    [ExplicitChild] public Button CreateServerButton { get; }
    [ExplicitChild] public Button JoinServerButton { get; }

    public override void _Ready()
    {
        base._Ready();

        CreateServerButton.Pressed += () =>
        {
            GetTree().Root.AddChild(Load<PackedScene>("res://ServerMain.tscn").Instantiate());
            GetParent().QueueFree();
        };

        JoinServerButton.Pressed += () =>
        {
            GetTree().Root.AddChild(Load<PackedScene>("res://ClientMain.tscn").Instantiate());
            GetParent().QueueFree();
        };
    }
}

