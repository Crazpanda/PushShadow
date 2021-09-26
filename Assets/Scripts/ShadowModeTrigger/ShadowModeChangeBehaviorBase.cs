using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowModeChangeBehaviorBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        ShadowModeManager.Instance.RegisterInteractable(this);
    }

    protected virtual void OnDestroy()
    {
        ShadowModeManager.Instance.UnregisterInteractable(this);
    }

    public virtual void OnShadowModeChanged(ShadowMode shadowMode)
    {
        Debug.Log($"[ShadowInteractable] {shadowMode}");
    }
}
