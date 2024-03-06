using Godot;
using System;
using static Godot.GD;
using System.Reflection;

namespace FarewellToFate;

public static class NodeExtensions
{
    public static SignalAwaiter GetEndOfFrame(this Node node) =>
        node.ToSignal(node.GetTree(), "process_frame");
}
