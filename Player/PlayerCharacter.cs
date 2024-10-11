using System;
using System.Diagnostics;
using System.Net;
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
	[Export] public float RunSpeedMultiplier { get; private set; } = 2f;
	[Export] public Direction Direction { get; private set; } = Direction.Down;

	[ExplicitChild] public CharacterBody2D CharacterBody2D { get; }
	[ExplicitChild] public AnimatedSprite2D CharacterSprite { get; }
	[ExplicitChild] public CollisionShape2D CollisionShape2D { get; }
	[ExplicitChild] public Camera2D Camera2D { get; }

	public PlayerMovableChecker PlayerMovableChecker { get; set; }

	public Vector2 MoveDirection { get; private set; } = Vector2.Zero;

	public override void _Ready()
	{
		base._Ready();
		Camera2D.Enabled = IsMultiplayerAuthority();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		// CharacterBody2D.GlobalPosition = CharacterBody2D.GlobalPosition.Round();
		CharacterBody2D.GlobalPosition = new()
		{
			X = Mathf.Max(CharacterBody2D.GlobalPosition.X, 0),
			Y = Mathf.Max(CharacterBody2D.GlobalPosition.Y, 0)
		};
	}

	public override void _PhysicsProcess(double delta)
	{
		if (IsMultiplayerAuthority())
		{
			base._PhysicsProcess(delta);
			if (!PlayerMovableChecker.IsPlayerMovable)
			{
				return;
			}
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
			var totalMoveSpeed = MoveSpeed;
			if (Input.IsActionPressed("Sprint"))
			{
				totalMoveSpeed *= RunSpeedMultiplier;
			}
			CharacterSprite.SpeedScale = totalMoveSpeed / MoveSpeed;
			CharacterSprite.Play($"{animation}{Direction}");
			CharacterBody2D.Velocity = MoveDirection.Normalized() * totalMoveSpeed;
		}
		CharacterBody2D.MoveAndSlide();
	}
}
