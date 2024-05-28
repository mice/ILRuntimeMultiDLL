using UnityEngine;

public class GameMain
{
    private static GameMain _instance = null;
    public static GameMain Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameMain();
            }
            return _instance;
        }
    }

    public const int UI_SCREEN_WIDTH = 641;
    public const int UI_SCREEN_HEIGHT = 1136;

    private GameMain() { }

    public void OnInit()
    {
        UnityEngine.Debug.LogError("IL GameMain OnInit:");
        var ui = new MainUIView();
        UnityEngine.Debug.LogError($"IL GameMain ui:{ui}");
    }

    /// <summary>
    /// 返回给外部的类型(注意此函数不能支持内部类型转换)
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public System.Type GetType(string name)
    {
        System.Type type = System.Type.GetType(name);
        if (null != type)
        {
            return type;
        }
        return null;
    }

    void OnDestroy()
    {

    }
}