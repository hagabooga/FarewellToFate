using Godot;
using System;
using System.Linq;

namespace FarewellToFate;



public partial class InventoryView : ExplicitNode
{
	[ExplicitChild] public HBoxContainer InventoryHotkeysHBox { get; }




	TextureButton[] inventoryHotkeys;







	public override void _Ready()
	{
		base._Ready();

		inventoryHotkeys = InventoryHotkeysHBox.GetChildren()
			.Cast<TextureButton>().ToArray();
	}

}
