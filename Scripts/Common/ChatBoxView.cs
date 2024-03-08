using Godot;

namespace FarewellToFate;

public partial class ChatBoxView : ExplicitNode, IChatBoxView
{
    public event LineEdit.TextSubmittedEventHandler TextSubmitted
    {
        add => MessageLineEdit.TextSubmitted += value;
        remove => MessageLineEdit.TextSubmitted -= value;
    }

    [ExplicitChild] public Label MessagesLabel { get; }
    [ExplicitChild] public LineEdit MessageLineEdit { get; }

    public string Messages { set => MessagesLabel.Text = value; }
    public string Message { get => MessageLineEdit.Text; set => MessageLineEdit.Text = value; }

    public override void _Ready()
    {
        base._Ready();

    }

}
