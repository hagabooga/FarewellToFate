using System.Diagnostics;
using System.Net.Http.Headers;
using Godot;
using static Godot.GD;

namespace FarewellToFate;

public partial class PlayerCharacter : ExplicitNode
{
	[Export] public float MoveSpeed { get; private set; } = 50;

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
	}

	public override void _PhysicsProcess(double delta)
	{
		if (IsMultiplayerAuthority())
		{
			base._PhysicsProcess(delta);
			MoveDirection = Input.GetVector("Left", "Right", "Up", "Down");
			if (MoveDirection.X < 0)
			{
				CharacterSprite.Play("WalkLeft");
			}
			else if (MoveDirection.X > 0)
			{
				CharacterSprite.Play("WalkRight");
			}
			else if (MoveDirection.Y < 0)
			{
				CharacterSprite.Play("WalkUp");
			}
			else if (MoveDirection.Y > 0)
			{
				CharacterSprite.Play("WalkDown");
			}
			else
			{
				CharacterSprite.Play("default");
			}
			CharacterBody2D.Velocity = MoveDirection.Normalized() * MoveSpeed;
		}
		CharacterBody2D.MoveAndSlide();
	}
}
