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
		get => id;
		set
		{
			Print($"{Multiplayer?.GetUniqueId()}: Setting Id to " + value);
			id = value;
		}
	}
	[Export]
	public string Username
	{
		get => username;
		set
		{
			Print($"{Multiplayer?.GetUniqueId()}: Setting Id({Id}).Username to " + value);
			username = value;
			PlayerCharacter.SetNameTag(username);
			Print($"PlayerCharacter:  {PlayerCharacter.NameTagLabel.Text}");
		}
	}

	[ExplicitChild] public PlayerCharacter PlayerCharacter { get; }

	public override void _EnterTree()
	{
		base._EnterTree();
		SetMultiplayerAuthority(int.Parse(Name));
	}

	public override void _Ready()
	{
		base._Ready();
	}
}
