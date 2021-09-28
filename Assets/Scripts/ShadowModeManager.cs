using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowModeManager : MonoBehaviour
{
    static ShadowModeManager _instance = null;
    public static ShadowModeManager Instance
    {
        get
        {
            return _instance;
        }
    }

    HashSet<ShadowModeChangeBehaviorBase> shadowInteractables;
    ShadowMode _currentShadowMode = ShadowMode.Normal;

    public ShadowMode CurrentShadowMode
    {
        get
        {
            return _currentShadowMode;
        }
    }

    HashSet<ShadowVolume> shadowsPlayerIn;
    public bool IsPlayerInShadow
    {
        get
        {
            return shadowsPlayerIn.Count > 0;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            shadowInteractables = new HashSet<ShadowModeChangeBehaviorBase>();
            shadowsPlayerIn = new HashSet<ShadowVolume>();
        }
        else
        {
            Debug.LogError("[ShadowModeManager] ShadowModeManager should be a singleton!");
            Destroy(this.gameObject);
        }
    }

    public void RegisterInteractable(ShadowModeChangeBehaviorBase interactable)
    {
        if (shadowInteractables.Contains(interactable))
        {
            Debug.LogWarning($"[ShadowModeManager] {interactable.gameObject.name} is already registered.");
            return;
        }
        shadowInteractables.Add(interactable);
    }

    public void UnregisterInteractable(ShadowModeChangeBehaviorBase interactable)
    {
        if (!shadowInteractables.Contains(interactable))
        {
            Debug.LogWarning($"[ShadowModeManager] {interactable.gameObject.name} is not registered.");
            return;
        }
        shadowInteractables.Remove(interactable);
    }

    public void OnPlayerEnterShadow(ShadowVolume shadowTrigger)
    {
        if (shadowsPlayerIn.Contains(shadowTrigger))
        {
            Debug.LogWarning($"[ShadowModeManager] Player is already in {shadowTrigger.gameObject.name}.");
            return;
        }
        shadowsPlayerIn.Add(shadowTrigger);
        Debug.Log($"[ShadowModeManager] Player entered {shadowTrigger.gameObject.name}.");
    }

    public void OnPlayerExitShadow(ShadowVolume shadowTrigger)
    {
        if (!shadowsPlayerIn.Contains(shadowTrigger))
        {
            Debug.LogWarning($"[ShadowModeManager] Player is not in {shadowTrigger.gameObject.name}.");
            return;
        }
        shadowsPlayerIn.Remove(shadowTrigger);
        Debug.Log($"[ShadowModeManager] Player exited {shadowTrigger.gameObject.name}, IsPlayerInShadow = {IsPlayerInShadow}");
    }

    public void ChangeShadowMode(ShadowMode shadowMode)
    {
        if (IsPlayerInShadow && shadowMode == ShadowMode.Interactive)
        {
            return;
        }
        _currentShadowMode = shadowMode;
        foreach (var shadowInterable in shadowInteractables)
        {
            shadowInterable.OnShadowModeChanged(shadowMode);
        }
    }
}
