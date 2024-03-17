using Godot;
using static Godot.GD;

namespace FarewellToFate;


public partial class Plant
{
    public partial class Factory(PlantDatabase plantDatabase) : Node
    {
        [Export] private PackedScene plantScene;

        override public void _Ready()
        {
            base._Ready();
            plantScene = Load<PackedScene>("res://Plants/Plant.tscn"); ;
        }

        public Plant CreatePlant(PlantName plantName)
        {
            var plant = plantScene.Instantiate<Plant>();
            AddChild(plant);
            plant.Data = plantDatabase[plantName];
            return plant;
        }
    }
}
