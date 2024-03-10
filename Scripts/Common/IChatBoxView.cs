using Godot;

namespace FarewellToFate;

public interface IChatBoxView
{
    event LineEdit.TextSubmittedEventHandler TextSubmitted;

    void ReceiveMessage(string message);
    string Message { get; set; }
}
