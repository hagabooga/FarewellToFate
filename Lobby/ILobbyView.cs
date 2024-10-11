using System;
using Godot;

namespace FarewellToFate;

public interface ILobbyView
{
    event LineEdit.TextChangedEventHandler IpAddressTextChanged;
    event LineEdit.TextChangedEventHandler UsernameTextChanged;
    event Action CreateServerButtonPressed;
    event Action JoinServerButtonPressed;


    void ToggleUI();
}