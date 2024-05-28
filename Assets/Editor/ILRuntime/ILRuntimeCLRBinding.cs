using UnityEditor;


[System.Reflection.Obfuscation(Exclude = true)]
public class ILRuntimeCLRBinding
{
    const string AUTO_GEN_ILRUNTIME_BINDING = "Assets/AutoGen/ILRuntime/Generated";
   

   [MenuItem("ILRuntime/通过自动分析热更DLL生成CLR绑定")]
    static void GenerateCLRBindingByAnalysis()
    {
        //用新的分析热更dll调用引用来生成绑定代码
        ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
         string[] dlls = new string[]
           {
                "HotFixApp",
                "HotFixCore",
                "HotFixData",
                "HotFixUI"
        };

        for (int i = 0; i < dlls.Length; i++)
        {
            var item = dlls[i];
            System.IO.FileStream fs = new System.IO.FileStream($"Assets/StreamingAssets/HotFixDLL/{item}.bytes", System.IO.FileMode.Open, System.IO.FileAccess.Read);

            {
                domain.LoadAssembly(fs);
                //Crossbind Adapter is needed to generate the correct binding code
            }
        }

        InitILRuntime(domain);
        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, AUTO_GEN_ILRUNTIME_BINDING);


        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("提示", "CLR绑定生成完成", "确认");
    }

    static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain domain)
    {
        //这里需要注册所有热更DLL中用到的跨域继承Adapter，否则无法正确抓取引用
        //domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
        //domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
        //domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
        //domain.RegisterValueTypeBinder(typeof(Rect), new RectBinder());

        //domain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
        //domain.RegisterCrossBindingAdaptor(new CBaseMsgHandlerAdapter());
        //domain.RegisterCrossBindingAdaptor(new WindowAdapter());
        //domain.RegisterCrossBindingAdaptor(new IComparer_1_Int32Adapter());
        //domain.RegisterCrossBindingAdaptor(new GComponentAdapter());
        //domain.RegisterCrossBindingAdaptor(new GButtonAdapter());
        //domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
        //domain.RegisterCrossBindingAdaptor(new QKFGUIDialogBaseAdapter());
        //domain.RegisterCrossBindingAdaptor(new QKBaseDataAdapter());
    }
}