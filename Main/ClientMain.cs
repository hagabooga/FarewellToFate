using System.Net;
using Godot;

namespace FarewellToFate;

public partial class ClientMain : AbstractMain
{
    [ExplicitChild] public MapView MapView { get; }

    public LobbyModel LobbyModel { get; set; }

    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        ENetClient eNetClient = new(LobbyModel);
        GetTree().Root.Multiplayer.MultiplayerPeer = eNetClient;
        container.RegisterInstance(eNetClient);

        RegisterNodeInstance(LobbyModel);



        RegisterSingleton<HotkeyInputs>();
        RegisterSingleton<IPlayerInformation, PlayerInformationClient>();
        RegisterSingleton<ChatBoxClientPresenter>();
        RegisterSingleton<ChatBoxNet>();
        RegisterSingleton<PlantDatabase>();
        RegisterSingleton<ItemDatabase>();
        RegisterSingleton<MapMousePresenter>();
        RegisterSingleton<Plant.Factory>();


        container.RegisterInstance(MapView);
        RegisterSingleton<ClientPlayerSpawner>();


        RegisterPackedSceneInstantiation<IChatBoxView>("res://ChatBox/ChatBoxView.tscn");
        RegisterPackedSceneInstantiation<InventoryView>("res://Items/InventoryView.tscn");


        VerifyAndAddNodesAndStartAsync();
    }
}