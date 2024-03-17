using Godot;
using System;
using static Godot.GD;

namespace FarewellToFate;


public partial class MapView : ExplicitNode
{
	[ExplicitChild] public Marker2D SpawnPoint { get; }
	[ExplicitChild] public TileMap Grass { get; }


	[ExplicitChild] public Sprite2D MapCursor { get; }


	public override void _Ready()
	{
		base._Ready();

	}


	public override void _Process(double delta)
	{
		base._Process(delta);
		var mouseGlobalPosition = Grass.GetGlobalMousePosition();
		MapCursor.GlobalPosition = new()
		{
			X = (int)(mouseGlobalPosition.X / 16) * 16,
			Y = (int)(mouseGlobalPosition.Y / 16) * 16
		};
	}

}
