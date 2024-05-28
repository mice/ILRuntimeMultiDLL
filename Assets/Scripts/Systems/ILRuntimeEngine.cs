using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Enviorment;
using System.Threading;
using System.IO;
using UnityEngine;
using ILRuntime.Mono.Cecil.Pdb;

public class ILRuntimeEngine:ISystemInitialize
{
    private AppDomain m_Appdomain;
    private ILTypeInstance m_ILInstance = null;
    public AppDomain AppDomain => m_Appdomain;

    private bool NeedDebug = true;
    #region 避免代码裁剪
    static System.Collections.Generic.List<ILTypeInstance> m_BindType1 = new System.Collections.Generic.List<ILTypeInstance>();
    static System.Collections.Generic.SortedList<ulong, ILTypeInstance> m_BindType2 = new System.Collections.Generic.SortedList<ulong, ILTypeInstance>();
    static System.Collections.Generic.Dictionary<ulong, ILTypeInstance> m_BindType3 = new System.Collections.Generic.Dictionary<ulong, ILTypeInstance>();
    #endregion

    public void Initialize()
    {
        InitAppDomain();
        LoadDLL();
        m_Appdomain.InitializeBindings();
        InitializeILRuntime();
        InitILMain();
    }

    private void InitAppDomain()
    {
        m_Appdomain = new AppDomain();
    }

    private void LoadDLL()
    {
        LoadMainDll("HotFixCore");
        LoadMainDll("HotFixData");
        LoadMainDll("HotFixUI");
        LoadMainDll("HotFixApp");
    }

    private void LoadMainDll(string module)
    {
        var filePathBytes = System.IO.Path.Combine(Application.streamingAssetsPath, $"HotFixDLL/{module}.bytes");
        var bytes = File.ReadAllBytes(filePathBytes);
        var msdll = new MemoryStream(bytes);

        MemoryStream pbdll = null;
        if (NeedDebug)
        {
            var filePathPdb = System.IO.Path.Combine(Application.streamingAssetsPath, $"HotFixDLL/{module}.pdb");
            var pdbBytes = File.ReadAllBytes(filePathPdb);
            pbdll = new MemoryStream(pdbBytes);
        }


        {
            try
            {
                m_Appdomain.LoadAssembly(msdll, pbdll, new PdbReaderProvider());
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError($"[Error]LoadILMainDll1:{module}:" + e);
            }
            Debug.LogError($"LoadModule:{module}");
        }
    }

    public ILTypeInstance CreateInstance(string typeName)
    {
        var tmpInstance = m_Appdomain.Instantiate(typeName);
        return tmpInstance;
    }
    
    public void Invoke()
    {
        m_Appdomain.Invoke("GameMain", "OnInit", m_ILInstance);
    }

    private void InitILMain()
    {
        //HelloWorld，第一次方法调用
        try
        {
            m_ILInstance = m_Appdomain.Instantiate("GameMain");
            if (m_ILInstance != null)
            {
                m_Appdomain.Invoke("GameMain", "OnInit", m_ILInstance);
            }
        }catch(System.Exception ex)
        {
            UnityEngine.Debug.LogError("[Error]InitILMain:" + ex);
        }
        Debug.LogError(m_ILInstance);
    }

    private void InitializeILRuntime()
    {
#if DEBUG && (UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE)
        //由于Unity的Profiler接口只允许在主线程使用，为了避免出异常，需要告诉ILRuntime主线程的线程ID才能正确将函数运行耗时报告给Profiler
        m_Appdomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
#endif
        //这里做一些需要的ILRuntime注册
        m_Appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, ILTypeInstance, System.Int32>();

        m_Appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, ILRuntime.Runtime.Intepreter.ILTypeInstance>();
    }
}