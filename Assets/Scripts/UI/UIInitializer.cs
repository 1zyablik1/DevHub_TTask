using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    void Awake()
    {
        var initScripts = GetComponentsInChildren<IUIInitable>(true);

        foreach (var scipt in initScripts)
        {
            scipt.Init();
        }
    }
}
