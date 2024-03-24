using Godot;
using System.Collections.Generic;
using System.Linq;




namespace FarewellToFate;

public partial class InventoryView : ExplicitNode
{
	[ExplicitChild] public HBoxContainer InventoryHotkeysHBox { get; }
	public Variant CurrentDragData { get; set; }

	IReadOnlyList<InventoryHotkeySlotView> inventoryHotkeys;





	public override void _Ready()
	{
		base._Ready();

		inventoryHotkeys = InventoryHotkeysHBox.GetChildren().Cast<InventoryHotkeySlotView>().ToArray();
	}

}
