using System.Collections.Generic;

namespace FarewellToFate;

public class PlayerMovableChecker
{
    readonly List<bool> moves = new List<bool>();

    public bool IsPlayerMovable => moves.Count == 0 || moves.TrueForAll(x => x);

    public PlayerMovableChecker(IChatBoxView chatBoxView)
    {
        chatBoxView.FocusedEntered += () => moves.Add(false);
        chatBoxView.FocusedExited += () => moves.Remove(false);
    }

}
