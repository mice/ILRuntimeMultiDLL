using System.Collections.Generic;

public class TestTestBstUtils
{
    private ILRuntimeEngine ilRuntime;
    private ILRuntime.Runtime.Intepreter.ILTypeInstance ilInst;

    ILRuntime.CLR.Method.IMethod _init_method;
    private List<ILRuntime.CLR.Method.IMethod> testMethods = new List<ILRuntime.CLR.Method.IMethod>();
    public TestTestBstUtils(ILRuntimeEngine ilRuntime)
    {
        this.ilRuntime = ilRuntime;
        ilInst = ilRuntime.CreateInstance("TestBSTUtils");
        _init_method  = ilInst.Type.GetMethod("Init", 0);

        testMethods.Add(ilInst.Type.GetMethod("TestDictSearch100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictSearch1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictSearch10000", 0));

        testMethods.Add(ilInst.Type.GetMethod("TestBinarySearch100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestBinarySearch1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestBinarySearch10000", 0));
        TestMethod();
    }

    public void TestMethod()
    {
        for (int i = 0; i < testMethods.Count; i++)
        {
            var tmpMethod = testMethods[i];
            UnityEngine.Profiling.Profiler.BeginSample(tmpMethod.Name);
           
            ilInst.Type.AppDomain.Invoke(tmpMethod, ilInst, System.Array.Empty<System.Object>());
           
            UnityEngine.Profiling.Profiler.EndSample();
        }
    }
}
