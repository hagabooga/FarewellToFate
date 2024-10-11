using System.Collections.Generic;

namespace FarewellToFate;

public class ActualPlayerMovableChecker : IPlayerMovableChecker
{
    readonly List<bool> moves = [];

    public bool IsPlayerMovable => moves.Count == 0 || moves.TrueForAll(x => x);

    public ActualPlayerMovableChecker(IChatBoxView chatBoxView)
    {
        chatBoxView.FocusedEntered += () => moves.Add(false);
        chatBoxView.FocusedExited += () => moves.Remove(false);
    }

}
