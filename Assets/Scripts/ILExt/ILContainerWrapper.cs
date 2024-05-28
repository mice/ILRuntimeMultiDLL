using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;

/// <summary>
/// 不支持重载.
/// </summary>
public class ILContainerWrapper
{
    private ILRuntime.CLR.TypeSystem.ILType ilType;
    private ILRuntime.Runtime.Intepreter.ILTypeInstance instance;
    private AppDomain appDomain;

    public IMethod GetMethod(string method)
    {
        return ilType.GetMethod(method);
    }

    public void Invoke(string method)
    {
        var ilMethod = ilType.GetMethod(method);
        if (ilMethod != null)
        {
            appDomain.Invoke(ilMethod, instance, System.Array.Empty<object>());
        }
    }

    public void Invoke<T>(string method, T p1)
    {
        var ilMethod = ilType.GetMethod(method);
        if (ilMethod != null)
        {
            appDomain.Invoke(ilMethod, instance, p1);
        }
    }

    public static ILContainerWrapper GetWrapper(AppDomain appDomain,string clsName)
    {
        var tmpType = appDomain.GetType(clsName);
        if (tmpType is ILRuntime.CLR.TypeSystem.ILType ilType)
        {
            var container = new ILContainerWrapper();
            container.ilType = ilType;
            container.appDomain = appDomain;
            container.instance = appDomain.Instantiate(clsName);
            return container;
        }

        return null;
    }

    public static ILContainerWrapper GetStaticWrapper(AppDomain appDomain, string clsName)
    {
        var tmpType = appDomain.GetType(clsName);
        if (tmpType is ILRuntime.CLR.TypeSystem.ILType ilType)
        {
            var container = new ILContainerWrapper();
            container.ilType = ilType;
            container.appDomain = appDomain;
            container.instance = null;
            return container;
        }

        return null;
    }
}
