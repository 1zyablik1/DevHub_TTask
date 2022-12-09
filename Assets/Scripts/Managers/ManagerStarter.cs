using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerStarter
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitialOnStart()
    {
        foreach (Type mytype in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(
            mytype => mytype.GetInterfaces().Contains(typeof(IInitableOnStart)))
            )
        {
            object myObject = (IInitableOnStart)Activator.CreateInstance(mytype);

            ((IInitableOnStart)myObject).Init();
            ((IInitableOnStart)myObject).Subscribe();
        }
    }
}
