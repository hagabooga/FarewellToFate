using Godot;

namespace FarewellToFate;

public record class ItemData(ItemName Name)
{
    public Texture2D Sprite { get; } = GD.Load<Texture2D>($"res://Items/Sprites/{Name}.png");
    public required int Price { get; init; }
}
