// using Godot;
// using static Godot.GD;
// using Godot.Collections;

// using FarewellToFate;

// public partial class Client : Node
// {
// 	public string IpAddress { get; set; } = "localhost";

// 	ENetMultiplayerPeer peer = new();

// 	public override void _Ready()
// 	{
// 		peer.CreateClient(IpAddress, Constants.Port);
// 		Multiplayer.MultiplayerPeer = peer;
// 	}

// 	// public event System.Action<MultiplayerPeer.ConnectionStatus> ConnectionUpdated;
// 	// public string ServerAddress { get; init; } = "localhost";
// 	// ENetMultiplayerPeer MultiplayerPeer { get; } = new();
// 	// Array connectedPeerIds = new();

// 	// public override void _Ready()
// 	// {
// 	// 	Multiplayer.ServerDisconnected += () =>
// 	// 	{
// 	// 		MultiplayerPeer.Close();
// 	// 		ConnectionUpdate();
// 	// 		Print("Disconnected from server.");
// 	// 	};
// 	// }

// 	// [Rpc()]
// 	// public void SyncPlayerList(Array updatedConnectedPeerIds)
// 	// {
// 	// 	connectedPeerIds = updatedConnectedPeerIds;
// 	// 	Print(MultiplayerPeer.GetUniqueId());
// 	// }

// 	// public void Connect()
// 	// {
// 	// 	Print("Connecting...");
// 	// 	MultiplayerPeer.CreateClient(ServerAddress, Constants.Port);
// 	// 	Multiplayer.MultiplayerPeer = MultiplayerPeer;
// 	// 	ConnectionUpdate();
// 	// }

// 	// public void Disconnect()
// 	// {
// 	// 	MultiplayerPeer.Close();
// 	// 	ConnectionUpdate();
// 	// 	Print("Disconnected.");
// 	// }


// 	// private void ConnectionUpdate()
// 	// {
// 	// 	ConnectionUpdated?.Invoke(MultiplayerPeer.GetConnectionStatus());
// 	// }


// }
