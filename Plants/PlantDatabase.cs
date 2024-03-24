using Godot;
using System;
using System.Collections.Generic;
using static Godot.GD;

namespace FarewellToFate;

public partial class PlantDatabase : Node
{
	readonly Dictionary<PlantName, PlantData> plantData = [];
	public override void _Ready()
	{
		base._Ready();

		foreach (var plantData in new PlantData[]
		{
			new(PlantName.Turnip)
			{
				Stages = 3,
				DaysToGrow = 3,
			},
			new(PlantName.Cauliflower)
			{
				Stages = 4,
				DaysToGrow = 4,
			},
		})
		{
			this.plantData.Add(plantData.Name, plantData);
		}
	}

	public PlantData this[PlantName plantName] => plantData[plantName];


}
