using Godot;
using static Godot.GD;
namespace FarewellToFate;

public partial class LoginView : ExplicitNode, ILoginView
{
    [ExplicitChild] public LineEdit UsernameLineEdit { get; }

    public event LineEdit.TextChangedEventHandler TextChanged
    {
        add => UsernameLineEdit.TextChanged += value;
        remove => UsernameLineEdit.TextChanged -= value;
    }

    public event LineEdit.TextSubmittedEventHandler TextSubmitted
    {
        add => UsernameLineEdit.TextSubmitted += value;
        remove => UsernameLineEdit.TextSubmitted -= value;
    }


}