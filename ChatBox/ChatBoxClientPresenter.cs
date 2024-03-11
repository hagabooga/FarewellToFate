using System;
using System.Collections.Generic;
using Fractural.Tasks;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ChatBoxClientPresenter
(
    IChatBoxView chatBoxView,
    ChatBoxNet model
) : Node, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
    }

    public async GDTask StartAsync()
    {
        chatBoxView.TextSubmitted += msg =>
        {
            if (msg.IsNullOrWhiteSpace()) return;
            chatBoxView.Message = "";
            model.SendServerMessage(msg);
        };

        model.MessageReceived += chatBoxView.ReceiveMessage;
    }
}
