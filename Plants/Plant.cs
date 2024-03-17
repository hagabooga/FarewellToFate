using Godot;
using System;
using static Godot.GD;

namespace FarewellToFate;


public partial class Plant : ExplicitNode
{
	private PlantData data = null;

	[Export] public int CurrentStage { get; private set; } = 0;

	[ExplicitChild] public Node2D PlantNode2D { get; }
	[ExplicitChild] public Sprite2D TilledSoilSprite { get; }
	[ExplicitChild] public Sprite2D PlantSprite { get; }


	public PlantData Data
	{
		get => data;
		private set
		{
			data = value;
			PlantSprite.Texture = data.Sprite;
			PlantSprite.Hframes = data.Stages;
		}
	}

	public override void _Ready()
	{
		base._Ready();
		PlantSprite.Visible = false;
	}

	public void Grow()
	{
		if (CurrentStage == data.Stages)
		{
			return;
		}
		CurrentStage++;
		if (CurrentStage == 1)
		{
			PlantSprite.Visible = true;
			PlantSprite.Frame++;
		}

	}
}
