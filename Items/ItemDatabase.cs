using System.Collections.Generic;
using Godot;

namespace FarewellToFate;

public partial class ItemDatabase : Node
{
    readonly Dictionary<ItemName, ItemData> itemData = [];

    public override void _Ready()
    {
        base._Ready();

        foreach (var itemData in new ItemData[]
        {
            new(ItemName.HealthPotion)
            {
                Price = 100,
            }
        })
        {
            this.itemData[itemData.Name] = itemData;
        }
    }
}
