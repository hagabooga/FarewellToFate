using Godot;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace FarewellToFate;


public partial class MapView : ExplicitNode
{
	[ExplicitChild] public Marker2D SpawnPoint { get; }
	[ExplicitChild] public TileMap GrassHills { get; }
	[ExplicitChild] public TileMap Dirt { get; }
	[ExplicitChild] public Sprite2D MapCursor { get; }


	public override void _Ready()
	{
		base._Ready();
	}


}
