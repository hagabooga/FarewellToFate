using System;
using Fractural.Tasks;
using Godot;

namespace FarewellToFate;

public static class Fast
{
    public static void CreateForgetGDTask(Func<GDTask> action) => GDTask.Create(action).Forget();
    public static void CreateForgetGDTaskWithFrameDelay(Func<GDTask> action) => GDTask.Create(async () =>
    {
        await GDTask.Yield();
        await action();
    }).Forget();


    public static Error RpcServer(this Node node, StringName method, params Variant[] args) => node.RpcId(1, method, args);
    public static Error RpcClients(this Node node, StringName method, params Variant[] args) => node.RpcId(0, method, args);
}
