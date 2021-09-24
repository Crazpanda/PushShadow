using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShadowModeManager.Instance.ChangeShadowMode(ShadowMode.Interactive);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ShadowModeManager.Instance.ChangeShadowMode(ShadowMode.Normal);
        }
    }
}
