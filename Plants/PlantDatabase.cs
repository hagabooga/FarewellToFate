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

		IReadOnlyCollection<PlantData> plantDatas =
		[
			new PlantData(PlantName.Turnip)
			{
				Stages = 3,
				DaysToGrow = 3,
			},
			new PlantData(PlantName.Cauliflower)
			{
				Stages = 4,
				DaysToGrow = 4,
			},
		];

		foreach (var plantData in plantDatas)
		{
			this.plantData.Add(plantData.Name, plantData);
		}
	}

	public PlantData this[PlantName plantName] => plantData[plantName];


}
