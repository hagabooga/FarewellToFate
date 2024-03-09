using Godot;
using static Godot.GD;
using Fractural.Tasks;
using System;
using Godot.Collections;
namespace FarewellToFate;

public partial class LobbyView : ExplicitNode
{
    [Export] PackedScene playerPs, serverPs, clientPs;

    [ExplicitChild] public LineEdit NameLineEdit { get; }
    [ExplicitChild] public LineEdit IpAddressLineEdit { get; }
    [ExplicitChild] public LineEdit MessageLineEdit { get; }
    [ExplicitChild] public LineEdit DebugLineEdit1 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit2 { get; }
    [ExplicitChild] public LineEdit DebugLineEdit3 { get; }
    [ExplicitChild] public Button CreateServerButton { get; }
    [ExplicitChild] public Button JoinServerButton { get; }
    [ExplicitChild] public Node Players { get; }

    public override void _Ready()
    {
        base._Ready();

        MessageLineEdit.TextSubmitted += text =>
        {
            MessageLineEdit.Text = "";
        };

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

