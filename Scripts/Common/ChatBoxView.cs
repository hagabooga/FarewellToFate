using Godot;

namespace FarewellToFate;

public partial class ChatBoxView : ExplicitNode, IChatBoxView
{
    [Export] PackedScene labelPs;

    public event LineEdit.TextSubmittedEventHandler TextSubmitted
    {
        add => MessageLineEdit.TextSubmitted += value;
        remove => MessageLineEdit.TextSubmitted -= value;
    }

    [ExplicitChild] public LineEdit MessageLineEdit { get; }
    [ExplicitChild] public VBoxContainer MessagesVBox { get; }

    public string Message { get => MessageLineEdit.Text; set => MessageLineEdit.Text = value; }

    public override void _Ready()
    {
        base._Ready();
    }

    public void ReceiveMessage(string message)
    {
        Label label = labelPs.Instantiate<Label>();
        label.Text = message;
        MessagesVBox.AddChild(label);
    }
}
