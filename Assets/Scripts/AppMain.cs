using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    ILRuntimeEngine ilRuntime;
    TestTestDict testtest;
    TestListOrDict testListOrDict;
    TestTestBstUtils testBstUtils;
    ILContainerWrapper wrapper;
    void Start()
    {
        ilRuntime = new ILRuntimeEngine();
        var il = new SystemInitializer();
        il.Add(ilRuntime);
        InitializeSystems(il);
      
    }

    void InitializeSystems(SystemInitializer il)
    {
        il.Initialize();
    }
}
