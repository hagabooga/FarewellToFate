using Godot;

namespace FarewellToFate;

public partial class Lobby : ExplicitNode
{
    [Explicit] public LineEdit NameLineEdit { get; }
    [Explicit] public LineEdit IpAddressLineEdit { get; }
    [Explicit] public LineEdit MessageLineEdit { get; }

    public override void _Ready()
    {
        base._Ready();

        MessageLineEdit.TextSubmitted += text =>
        {
            MessageLineEdit.Text = "";
        };
    }

}

