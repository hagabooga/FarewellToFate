using Fractural.Tasks;
using Godot;
using static Godot.GD;
namespace FarewellToFate;

public partial class ClientPlayerSpawner
(
    MapView mapView,
    IPlayerInformation playerInformation,
    IChatBoxView chatBoxView
) : Node, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
    }

    public async GDTask StartAsync()
    {
        Print("Starting PlayerSpawner");
        playerInformation.Spawned += node => Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            Print($"Spawning player: {node}");
            playerInformation.IdToPlayer[long.Parse(node.Name)] = (Player)node;
            // Do player init here
            if (node is Player player)
            {
                player.PlayerCharacter.CharacterBody2D.GlobalPosition = mapView.SpawnPoint.GlobalPosition;
                player.PlayerCharacter.PlayerMovableChecker = new ActualPlayerMovableChecker(chatBoxView);
            }
        });
    }


}
