using Godot;

namespace FarewellToFate;

public partial class LoginView : ExplicitNode, ILoginView
{
    [ExplicitChild] public LineEdit UsernameLineEdit { get; }

    public event LineEdit.TextSubmittedEventHandler TextSubmitted
    {
        add => UsernameLineEdit.TextSubmitted += value;
        remove => UsernameLineEdit.TextSubmitted -= value;
    }

    public override void _Ready()
    {
        base._Ready();
    }

}
