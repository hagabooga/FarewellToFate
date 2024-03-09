using Godot;

namespace FarewellToFate;


public interface ILoginView
{
    event LineEdit.TextSubmittedEventHandler TextSubmitted;
}
