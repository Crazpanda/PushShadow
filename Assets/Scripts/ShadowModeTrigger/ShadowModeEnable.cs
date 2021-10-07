using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowModeEnable : ShadowModeChangeBehaviorBase
{
    public bool disableInShadowMode = false;
    public GameObject[] gameObjsToEnable;

    protected override void Start()
    {
        base.Start();

        OnShadowModeChanged(ShadowModeManager.Instance.CurrentShadowMode);
    }

    private void OnEnable()
    {
        if (ShadowModeManager.Instance == null)
        {
            return;
        }

        OnShadowModeChanged(ShadowModeManager.Instance.CurrentShadowMode);
    }

    public override void OnShadowModeChanged(ShadowMode shadowMode)
    {
        if (gameObjsToEnable.Length == 0)
        {
            return;
        }

        bool newGameObjState = disableInShadowMode ? shadowMode != ShadowMode.Interactive : shadowMode == ShadowMode.Interactive;

        foreach (var gameObj in gameObjsToEnable)
        {
            gameObj.SetActive(newGameObjState);
        }
    }
}
