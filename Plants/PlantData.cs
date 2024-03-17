using Godot;
using static Godot.GD;

namespace FarewellToFate;

public record class PlantData(PlantName Name)
{
    public Texture2D Sprite { get; } = Load<Texture2D>($"res://Plants/Sprites/{Name}.png");
    public required int Stages { get; init; }
    public required int DaysToGrow { get; init; }
}
