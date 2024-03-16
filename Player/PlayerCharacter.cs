using System.Diagnostics;
using System.Net.Http.Headers;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class PlayerCharacter : ExplicitNode
{
	public enum Animation
	{
		Idle,
		Walk,
	}

	[Export] public float MoveSpeed { get; private set; } = 50;
	[Export] public Direction Direction { get; private set; } = Direction.Down;

	[ExplicitChild] public CharacterBody2D CharacterBody2D { get; }
	[ExplicitChild] public AnimatedSprite2D CharacterSprite { get; }
	[ExplicitChild] public CollisionShape2D CollisionShape2D { get; }
	[ExplicitChild] public Camera2D Camera2D { get; }


	public Vector2 MoveDirection { get; private set; } = Vector2.Zero;

	public override void _Ready()
	{
		base._Ready();
		Camera2D.Enabled = IsMultiplayerAuthority();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		CharacterBody2D.GlobalPosition = CharacterBody2D.GlobalPosition.Round();
		CharacterBody2D.ZIndex = (int)CharacterBody2D.GlobalPosition.Y;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (IsMultiplayerAuthority())
		{
			base._PhysicsProcess(delta);
			MoveDirection = Input.GetVector(Direction.Left.ToString(),
								   Direction.Right.ToString(),
								   Direction.Up.ToString(),
								   Direction.Down.ToString());
			var animation = Animation.Idle;
			if (MoveDirection != Vector2.Zero)
			{
				animation = Animation.Walk;
			}
			if (MoveDirection.X < 0)
			{
				Direction = Direction.Left;
			}
			else if (MoveDirection.X > 0)
			{
				Direction = Direction.Right;
			}
			else if (MoveDirection.Y < 0)
			{
				Direction = Direction.Up;
			}
			else if (MoveDirection.Y > 0)
			{
				Direction = Direction.Down;
			}
			CharacterSprite.Play($"{animation}{Direction}");
			CharacterBody2D.Velocity = MoveDirection.Normalized() * MoveSpeed;
		}
		CharacterBody2D.MoveAndSlide();
	}
}
