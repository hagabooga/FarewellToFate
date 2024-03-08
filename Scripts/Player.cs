using Godot;
using static Godot.GD;
namespace FarewellToFate;

public partial class Player : ExplicitNode
{
	private long id;
	private string username;
	[Export]
	public long Id
	{
		get => id; set
		{
			Print($"{Multiplayer?.GetUniqueId()}: Setting Id to " + value);
			id = value;
		}
	}
	[Export]
	public string Username
	{
		get => username; set
		{
			Print($"{Multiplayer?.GetUniqueId()}: Setting Username to " + value);
			username = value;
		}
	}

	public override void _Ready()
	{
		base._Ready();
	}
}
