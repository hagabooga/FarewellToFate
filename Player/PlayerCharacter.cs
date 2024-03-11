using System.Diagnostics;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class PlayerCharacter : ExplicitNode
{
	[Export] public float MoveSpeed { get; private set; } = 300;

	[ExplicitChild] public CharacterBody2D CharacterBody2D { get; }
	[ExplicitChild] public Sprite2D Sprite2D { get; }

	public Vector2 MoveDirection { get; private set; } = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		if (IsMultiplayerAuthority())
		{
			base._PhysicsProcess(delta);
			MoveDirection = Vector2.Zero;

			if (Input.IsActionPressed("ui_up"))
			{
				MoveDirection += Vector2.Up;
			}
			if (Input.IsActionPressed("ui_down"))
			{
				MoveDirection += Vector2.Down;
			}
			if (Input.IsActionPressed("ui_left"))
			{
				MoveDirection += Vector2.Left;
			}
			if (Input.IsActionPressed("ui_right"))
			{
				MoveDirection += Vector2.Right;
			}
			CharacterBody2D.Velocity = MoveDirection.Normalized() * MoveSpeed;
		}
		CharacterBody2D.MoveAndSlide();
	}
}
