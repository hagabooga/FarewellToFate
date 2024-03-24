using Godot;
using static Godot.GD;
using Fractural.Tasks;
namespace FarewellToFate;

public partial class LobbyPresenter(ILobbyView view, LobbyModel model) : Node, IAsyncStartable
{
    public async GDTask StartAsync()
    {
        view.IpAddressTextChanged += x => model.IpAddress = x;

        view.CreateServerButtonPressed += () =>
        {
            var node = Load<PackedScene>("res://Main/ServerMain.tscn").Instantiate<ServerMain>();
            node.LobbyModel = model;
            GetTree().Root.AddChild(node);
            GetParent().SetProcess(false);

            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Minimized);
        };

        view.JoinServerButtonPressed += () =>
        {
            var node = Load<PackedScene>("res://Main/ClientMain.tscn").Instantiate<ClientMain>();
            node.LobbyModel = model;
            GetTree().Root.AddChild(node);
            GetParent().SetProcess(false);
            view.ToggleUI();
        };
    }
}
