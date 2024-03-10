using Fractural.Tasks;
using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Godot.GD;
namespace FarewellToFate;

public abstract partial class AbstractMain : ExplicitNode
{
    protected readonly SimpleInjector.Container container = new();
    protected readonly List<Type> typesRegisteredAsNode = [];

    public override void _Ready()
    {
        base._Ready();
    }

    protected void RegisterPackedSceneInstantiation<T>(string path) where T : class
    {
        RegisterPackedSceneInstantiation<T>(Load<PackedScene>(path));
    }

    protected void RegisterPackedSceneInstantiation<T>(PackedScene ps) where T : class
    {
        var type = typeof(T);
        T node = ps.Instantiate<T>();
        RegisterNodeInstance(node);
        typesRegisteredAsNode.Add(type);
    }

    protected void RegisterSingleton<T>() where T : class
    {
        var type = typeof(T);
        var genericMethod = SimpleInjectorUtility.RegisterSingleton1Type0Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, []);
        typesRegisteredAsNode.Add(type);
    }

    protected void AddRegisteredNodes(Type type)
    {
        var genericMethod = SimpleInjectorUtility.GetInstance1Type0Args.MakeGenericMethod(type);
        var node = (Node)genericMethod.Invoke(container, []);
        GetTree().Root.AddChild(node, true);
        node.Name = type.Name;
    }

    protected void RegisterNodeInstance<T>(T node) where T : class
    {
        Print(node.GetType().Name);
        var type = typeof(T);
        var genericMethod = SimpleInjectorUtility.RegisterInstance1Type1Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, [node]);
    }


    protected void VerifyAndAddNodesAndStartAsync()
    {
        container.Verify();

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(AddRegisteredNodes);
        });

        Fast.CreateForgetGDTaskWithFrameDelay(async () =>
        {
            typesRegisteredAsNode.ForEach(x =>
            {
                if (typeof(IAsyncStartable).IsAssignableFrom(x))
                {
                    var genericMethod = SimpleInjectorUtility.GetInstance1Type0Args.MakeGenericMethod(x);
                    var node = (IAsyncStartable)genericMethod.Invoke(container, []);
                    node.StartAsync().Forget();
                }
            });
        });
    }
}
