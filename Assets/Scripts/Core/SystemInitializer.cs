using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SystemInitializer
{
    public List<ISystemInitialize> systems = new List<ISystemInitialize>();
    public void Add(ISystemInitialize system)
    {
        if (systems.Contains(system))
            return;
        systems.Add(system);
    }

    public void Initialize()
    {
        foreach(var item in systems)
        {
            try
            {
                item.Initialize();
            }catch(System.Exception e)
            {
                UnityEngine.Debug.LogError(e);
            }
        }
    }
}
