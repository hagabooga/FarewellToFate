using System;
using Godot;

namespace FarewellToFate;

public interface ILobbyView
{
    event LineEdit.TextChangedEventHandler IpAddressTextChanged;
    event Action CreateServerButtonPressed;
    event Action JoinServerButtonPressed;
}