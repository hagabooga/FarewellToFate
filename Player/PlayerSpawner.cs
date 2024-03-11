using Fractural.Tasks;
using Godot;
using static Godot.GD;
namespace FarewellToFate;

public partial class PlayerSpawner
(
    SoccerFieldTest soccerFieldTest,
    IPlayerInformation playerInformation
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
            if (node is Player player)
            {
                player.PlayerCharacter.CharacterBody2D.GlobalPosition = soccerFieldTest.SpawnPoint.GlobalPosition;
            }
        });
    }


}
