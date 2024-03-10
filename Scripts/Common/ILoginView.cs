using Godot;

namespace FarewellToFate;


public interface ILoginView
{
    event LineEdit.TextChangedEventHandler TextChanged;
    event LineEdit.TextSubmittedEventHandler TextSubmitted;
}
