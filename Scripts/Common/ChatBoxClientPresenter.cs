using System;
using System.Collections.Generic;
using Fractural.Tasks;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class ChatBoxPresenter
(
    IChatBoxView view,
    ChatBoxModel model
) : Node
{
    public override void _Ready()
    {
        base._Ready();
        view.TextSubmitted += text =>
        {
            if (text.IsNullOrWhiteSpace()) return;
            view.Message = "";
            this.RpcServer(nameof(model.ReceiveMessage), text);
        };

        model.ChatBoxUpdated += () => Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            view.Message = string.Join("\n", model.Messages);
        });
    }
}
