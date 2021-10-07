using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTrigger : MonoBehaviour
{
    public bool needInteractWith = false;
    public bool canTriggerInShadowMode = false;
    public bool canTriggerInNormalMode = false;

    public GameplayEvent[] triggeredEvents;

    public bool triggerIsActive = false;
    bool playerInTrigger = false;

    bool CanTrigger
    {
        get
        {
            bool inShadowMode =
                ShadowModeManager.Instance.CurrentShadowMode == ShadowMode.Interactive;

            return triggerIsActive
                && playerInTrigger
                && (inShadowMode && canTriggerInShadowMode || !inShadowMode && canTriggerInNormalMode);
        }
    }

    public void OnTriggered()
    {
        foreach (var gameplayEvent in triggeredEvents)
        {
            gameplayEvent.OnEventTriggered();
        }
    }

    private void Awake()
    {
        playerInTrigger = false;
    }

    private void FixedUpdate()
    {
        if ((!CanTrigger) || needInteractWith)
        {
            return;
        }

        OnTriggered();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerIsActive || !other.CompareTag("Player"))
        {
            return;
        }

        playerInTrigger = true;

        if (needInteractWith)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.OnPlayerInteract.AddListener(OnTriggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!triggerIsActive || !other.CompareTag("Player"))
        {
            return;
        }

        playerInTrigger = false;

        if (needInteractWith)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.OnPlayerInteract.RemoveListener(OnTriggered);
        }
    }

}
