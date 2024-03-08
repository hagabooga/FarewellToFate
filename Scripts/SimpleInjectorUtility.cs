using System.Linq;
using System.Reflection;

namespace FarewellToFate;

public static class SimpleInjectorUtility
{
    public static MethodInfo RegisterSingleton1Type0Args { get; }
    public static MethodInfo RegisterInstance1Type1Args { get; }
    public static MethodInfo GetInstance1Type0Args { get; }

    static SimpleInjectorUtility()
    {
        var methodInfos = typeof(SimpleInjector.Container).GetMethods();
        RegisterSingleton1Type0Args = methodInfos.Single(x => x.IsGenericMethod
                                                              && x.Name == "RegisterSingleton"
                                                              && x.GetParameters().Length == 0
                                                              && x.GetGenericArguments().Length == 1);
        RegisterInstance1Type1Args = methodInfos.Single(x => x.IsGenericMethod
                                                             && x.Name == "RegisterInstance"
                                                             && x.GetParameters().Length == 1
                                                             && x.GetGenericArguments().Length == 1);
        GetInstance1Type0Args = methodInfos.Single(x => x.IsGenericMethod
                                                        && x.Name == "GetInstance"
                                                        && x.GetParameters().Length == 0
                                                        && x.GetGenericArguments().Length == 1);
    }
}
