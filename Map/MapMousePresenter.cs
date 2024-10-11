using Fractural.Tasks;
using Godot;
using System;
using static Godot.GD;

namespace FarewellToFate;


public partial class MapMousePresenter(
    MapView view,
    Plant.Factory plantFactory
) : Node, IAsyncStartable
{
    public async GDTask StartAsync()
    {

    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        var grassLocalMousePosition = view.GrassHills.GetLocalMousePosition();
        var mouseGlobalPosition = view.GrassHills.GetGlobalMousePosition();
        Vector2I globalCell = new()
        {
            X = Math.Max(0, (int)(mouseGlobalPosition.X / view.GrassHills.TileSet.TileSize.X)),
            Y = Math.Max(0, (int)(mouseGlobalPosition.Y / view.GrassHills.TileSet.TileSize.Y)),
        };

        Vector2I cellGlobalPosition = new()
        {
            X = Math.Max(0, globalCell.X * view.GrassHills.TileSet.TileSize.X),
            Y = Math.Max(0, globalCell.Y * view.GrassHills.TileSet.TileSize.Y),
        };
        if (Input.IsActionJustPressed("ClickLeft"))
        {
            // Print(globalCell);
            var dirtCell = view.Dirt.GetCellAtlasCoords(0, globalCell);
            // Print(dirtCell);
            if (dirtCell == Vector2I.One || dirtCell.Y == 5 || dirtCell.Y == 6)
            {
                var plant = plantFactory.CreatePlant(PlantName.Turnip);
                plant.PlantNode2D.GlobalPosition = cellGlobalPosition;
            }
            else
            {

            }
        }

        view.MapCursor.GlobalPosition = cellGlobalPosition;
    }
}
