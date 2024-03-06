using Godot;
using System;
using static Godot.GD;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FarewellToFate;

public partial class Main : ExplicitNode
{
    [Export] PackedScene lobbyPs;

    static MethodInfo RegisterSingleton1Type0Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                    && x.Name == "RegisterSingleton"
                    && x.GetParameters().Length == 0
                    && x.GetGenericArguments().Length == 1);

    static MethodInfo RegisterInstance1Type1Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                     && x.Name == "RegisterInstance"
                     && x.GetParameters().Length == 1
                     && x.GetGenericArguments().Length == 1);


    static MethodInfo GetInstance1Type0Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                    && x.Name == "GetInstance"
                    && x.GetParameters().Length == 0
                    && x.GetGenericArguments().Length == 1);

    readonly SimpleInjector.Container container = new();
    readonly List<Type> typesRegisteredAsNode = new();


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
        var genericMethod = RegisterInstance1Type1Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, new object[] { node });
        AddChild(node);
        node.Name = type.Name;
    }

    void Register<T>() where T : Node
    {
        var type = typeof(T);
        var genericMethod = RegisterSingleton1Type0Args.MakeGenericMethod(type);
        genericMethod.Invoke(container, Array.Empty<object>());
        typesRegisteredAsNode.Add(type);
    }

    void AddRegisteredNodes(Type type)
    {
        var genericMethod = GetInstance1Type0Args.MakeGenericMethod(type);
        var node = (Node)genericMethod.Invoke(container, Array.Empty<object>());
        AddChild(node);
        node.Name = type.Name;
    }

}
