using System.Collections.Generic;

public class TestTestDict
{
    private ILRuntimeEngine ilRuntime;
    private ILRuntime.Runtime.Intepreter.ILTypeInstance ilInst;

    ILRuntime.CLR.Method.IMethod _init_method;
    private List<ILRuntime.CLR.Method.IMethod> testMethods = new List<ILRuntime.CLR.Method.IMethod>();
    public TestTestDict(ILRuntimeEngine ilRuntime)
    {
        this.ilRuntime = ilRuntime;
        ilInst = ilRuntime.CreateInstance("TestDict");
        _init_method  = ilInst.Type.GetMethod("Init", 0);

        testMethods.Add(ilInst.Type.GetMethod("TestDictForeach100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictForeach1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictForeach10000", 0));

        testMethods.Add(ilInst.Type.GetMethod("TestDictValuesForeach100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictValuesForeach1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestDictValuesForeach10000", 0));

        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesForeach100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesForeach1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesForeach10000", 0));


        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesFor100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesFor1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictValuesFor10000", 0));


        testMethods.Add(ilInst.Type.GetMethod("TestListDictKeysFor100", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictKeysFor1000", 0));
        testMethods.Add(ilInst.Type.GetMethod("TestListDictKeysFor10000", 0));
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
