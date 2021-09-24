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

    SortedSet<ShadowInteractableBase> shadowInteractables;
    ShadowMode _currentShadowMode = ShadowMode.Normal;

    public ShadowMode CurrentShadowMode
    {
        get
        {
            return _currentShadowMode;
        }
    }


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            shadowInteractables = new SortedSet<ShadowInteractableBase>();
        }
        else
        {
            Debug.LogError("[ShadowModeManager] ShadowModeManager should be a singleton!");
            Destroy(this.gameObject);
        }
    }

    public void RegisterInteractable(ShadowInteractableBase interactable)
    {
        if (shadowInteractables.Contains(interactable))
        {
            Debug.LogWarning($"[ShadowModeManager] {interactable.gameObject.name} is already registered.");
            return;
        }
        shadowInteractables.Add(interactable);
    }

    public void UnregisterInteractable(ShadowInteractableBase interactable)
    {
        if (!shadowInteractables.Contains(interactable))
        {
            Debug.LogWarning($"[ShadowModeManager] {interactable.gameObject.name} is not registered.");
            return;
        }
        shadowInteractables.Remove(interactable);
    }

    public void ChangeShadowMode(ShadowMode shadowMode)
    {
        _currentShadowMode = shadowMode;
        foreach (var shadowInterable in shadowInteractables)
        {
            shadowInterable.OnShadowModeChanged(shadowMode);
        }
    }
}
