using Godot;
using System;

namespace FarewellToFate;

public partial class Player : ExplicitNode
{
	[Export] long id;

	[Explicit] public MultiplayerSynchronizer StatsSynchronizer { get; }

	public long Id
	{
		get => id;
		set
		{
			id = value;
			StatsSynchronizer.SetMultiplayerAuthority((int)value);
			StatsSynchronizer.SetProcess(StatsSynchronizer.GetMultiplayerAuthority() == StatsSynchronizer.Multiplayer.GetUniqueId());
		}
	}

	[Export] public string Username { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
