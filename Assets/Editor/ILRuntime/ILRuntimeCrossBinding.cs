using UnityEditor;

[System.Reflection.Obfuscation(Exclude = true)]
public class ILRuntimeCrossBinding
{
   [MenuItem("ILRuntime/生成跨域继承适配器")]
    static void GenerateCrossbindAdapter()
    {
        //由于跨域继承特殊性太多,只需要生成一次就够
        //自动生成无法实现完全无副作用生成，所以这里提供的代码自动生成主要是给大家生成个初始模版，简化大家的工作
        //大多数情况直接使用自动生成的模版即可，如果遇到问题可以手动去修改生成后的文件，因此这里需要大家自行处理是否覆盖的问题

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/QKILRuntime/CrossbindAdapter/GButtonAdapter.cs"))
        //{
        //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(GButton), "FairyGUI"));
        //}

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/QKILRuntime/CrossbindAdapter/GComponentAdapter.cs"))
        //{
        //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(GComponent), "FairyGUI"));
        //}

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/QKILRuntime/CrossbindAdapter/CoroutineIEnumeratorAdapter.cs"))
        //{
        //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(IEnumerator<object>), ""));
        //}

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/QKILRuntime/CrossbindAdapter/QKFGUIDialogBaseAdapter.cs"))
        //{
        //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(QKFGUIDialogBase), "QKFGUI"));
        //}

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/QKILRuntime/CrossbindAdapter/QKBaseDataAdapter.cs"))
        //{
        //    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(QKBaseData), "QK"));
        //}

        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("提示", "跨域继承适配器生成完成", "确认");
    }
}