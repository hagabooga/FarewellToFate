using System;
using System.Collections.Generic;
using Fractural.Tasks;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ChatBoxClientPresenter
(
    IChatBoxView view,
    ChatBoxNet model
) : Node, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
    }

    public async GDTask StartAsync()
    {
        view.TextSubmitted += msg =>
        {
            if (msg.IsNullOrWhiteSpace()) return;
            view.Message = "";
            model.SendServerMessage(
                msg);
        };

        model.MessageReceived += view.ReceiveMessage;
    }
}
