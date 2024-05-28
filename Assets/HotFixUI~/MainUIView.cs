using HotFixData;
using UnityEngine;

public class MainUIView
{
    public MainUIView()
    {
        var DataMine = new DataMine();
        DataMine.Add(new ModuleConfigData());
        UnityEngine.Debug.LogError("IL MainUIView OnInit:");
    }

    public void OnStart()
    {
        UnityEngine.Debug.LogError("IL MainUIView OnStart:");
    }
}