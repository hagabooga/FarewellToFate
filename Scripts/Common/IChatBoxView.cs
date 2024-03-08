using Godot;

namespace FarewellToFate;

public interface IChatBoxView
{
    event LineEdit.TextSubmittedEventHandler TextSubmitted;

    string Messages { set; }
    string Message { get; set; }
}
