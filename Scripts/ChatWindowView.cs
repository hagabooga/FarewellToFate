using Godot;
using Godot.Collections;

namespace FarewellToFate;

public partial class ChatWindowView : ExplicitNode
{
	[ExplicitChild] public Label MessagesLabel { get; }
	[ExplicitChild] public LineEdit MessageLineEdit { get; }



	public override void _Ready()
	{
		base._Ready();

		MessageLineEdit.TextSubmitted += text =>
		{
			MessageLineEdit.Text = "";
			RpcId(1, nameof(SendMessage), text);
		};
	}


	[Rpc(MultiplayerApi.RpcMode.AnyPeer)]
	void SendMessage(string message)
	{
		RpcId(1, nameof(ReceiveMessage), message);
	}

	[Rpc(MultiplayerApi.RpcMode.AnyPeer)]
	void ReceiveMessage(string message)
	{
		MessagesLabel.Text += message + "\n";
	}
}
