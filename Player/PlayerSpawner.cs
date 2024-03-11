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

            (node as Player).PlayerCharacter.CharacterBody2D.Position = soccerFieldTest.SpawnPoint.Position;
        });
    }


}
