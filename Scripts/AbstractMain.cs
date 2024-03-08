using Godot;
using System;
using System.Collections.Generic;

namespace FarewellToFate;

public abstract partial class AbstractMain : ExplicitNode
{
    protected readonly SimpleInjector.Container container = new();
    protected readonly List<Type> typesRegisteredAsNode = [];

    protected void RegisterNode<T>(T node) where T : Node
    {
        var type = typeof(T);
        var genericMethod = SimpleInjectorUtility.RegisterInstance1Type1Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, [node]);
        node.Name = type.Name;
    }

    protected void RegisterPackedSceneInstantiation<T>(string path) where T : Node
    {
        RegisterPackedSceneInstantiation<T>(GD.Load<PackedScene>(path));
    }

    protected void RegisterPackedSceneInstantiation<T>(PackedScene ps) where T : Node
    {
        var type = typeof(T);
        T node = ps.Instantiate<T>();
        RegisterNode(node);
        typesRegisteredAsNode.Add(type);
    }

    protected void RegisterSingleton<T>() where T : Node
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
}
