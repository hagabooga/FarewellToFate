using Godot;
using System;

using static Godot.GD;

namespace FarewellToFate;

public partial class InventoryHotkeySlotView : TextureRect
{
	public ItemData ItemData { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		var inventoryHotkeySlot = data.As<InventoryHotkeySlotView>();
		Print(inventoryHotkeySlot.ItemData);
		base._DropData(atPosition, data);
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		return true;
	}

	public override Variant _GetDragData(Vector2 atPosition)
	{
		return this;
	}
}
