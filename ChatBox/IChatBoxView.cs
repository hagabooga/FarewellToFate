using System;
using Godot;

namespace FarewellToFate;

public interface IChatBoxView
{
    event LineEdit.TextSubmittedEventHandler TextSubmitted;
    event Action FocusedEntered;
    event Action FocusedExited;

    void ReceiveMessage(string message);
    string Message { get; set; }
}
