using Godot;
using System;
using static Godot.GD;
using System.Collections.Generic;

namespace FarewellToFate;


public partial class Main : ExplicitNode
{
    [Export] PackedScene lobbyPs;


    readonly SimpleInjector.Container container = new();
    readonly List<Type> typesRegisteredAsNode = [];

    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        Register<HotkeyInputs>();
        RegisterPackedScene<Lobby>(lobbyPs);

        container.Verify();

        typesRegisteredAsNode.ForEach(x => AddRegisteredNodes(x));
    }

    void RegisterPackedScene<T>(PackedScene ps) where T : Node
    {
        Node node = ps.Instantiate<T>();
        Type type = typeof(T);
        var genericMethod = SimpleInjectorUtility.RegisterInstance1Type1Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, [node]);
        AddChild(node);
        node.Name = type.Name;
    }

    void Register<T>() where T : Node
    {
        var type = typeof(T);
        var genericMethod = SimpleInjectorUtility.RegisterSingleton1Type0Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, []);
        typesRegisteredAsNode.Add(type);
    }

    void AddRegisteredNodes(Type type)
    {
        var genericMethod = SimpleInjectorUtility.GetInstance1Type0Args.MakeGenericMethod(type);
        var node = (Node)genericMethod.Invoke(container, []);
        AddChild(node);
        node.Name = type.Name;
    }
}
