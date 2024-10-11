using System;
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

    public event Action FocusedEntered
    {
        add => MessageLineEdit.FocusEntered += value;
        remove => MessageLineEdit.FocusEntered -= value;
    }

    public event Action FocusedExited
    {
        add => MessageLineEdit.FocusExited += value;
        remove => MessageLineEdit.FocusExited -= value;
    }



    [ExplicitChild] public LineEdit MessageLineEdit { get; }
    [ExplicitChild] public ScrollContainer MessagesScrollContainer { get; }
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
        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            MessagesScrollContainer.ScrollVertical = (int)MessagesScrollContainer.GetVScrollBar().MaxValue;
        });
    }
}
