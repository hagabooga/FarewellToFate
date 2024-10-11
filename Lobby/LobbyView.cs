using Godot;
using System;
using Godot.Collections;
namespace FarewellToFate;


public partial class LobbyView : ExplicitNode, ILobbyView
{
    [ExplicitChild] public Button CreateServerButton { get; }
    [ExplicitChild] public Button JoinServerButton { get; }
    [ExplicitChild] public LineEdit IpAddressLineEdit { get; }
    [ExplicitChild] public CanvasLayer CanvasLayer { get; }
    [ExplicitChild] public LineEdit UsernameLineEdit { get; }

    public string IpAddress => IpAddressLineEdit.Text;

    public event LineEdit.TextChangedEventHandler UsernameTextChanged
    {
        add => UsernameLineEdit.TextChanged += value;
        remove => UsernameLineEdit.TextChanged -= value;
    }

    public event LineEdit.TextChangedEventHandler IpAddressTextChanged
    {
        add => IpAddressLineEdit.TextChanged += value;
        remove => IpAddressLineEdit.TextChanged -= value;
    }
    public event Action CreateServerButtonPressed
    {
        add => CreateServerButton.Pressed += value;
        remove => CreateServerButton.Pressed -= value;
    }
    public event Action JoinServerButtonPressed
    {
        add => JoinServerButton.Pressed += value;
        remove => JoinServerButton.Pressed -= value;
    }

    public void ToggleUI()
    {
        CanvasLayer.Visible = !CanvasLayer.Visible;
    }


    public override void _Ready()
    {
        base._Ready();
    }
}