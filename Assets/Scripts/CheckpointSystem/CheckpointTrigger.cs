using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public bool needInteractWith = false;
    public bool canTriggerInShadowMode = false;
    public bool canTriggerInNormalMode = false;

    public GameplayEvent[] triggeredEvents;

    [HideInInspector]
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

    public void OnCheckpointTriggered()
    {
        foreach (var gameplayEvent in triggeredEvents)
        {
            gameplayEvent.OnEventTriggered();
        }
        CheckpointManager.Instance.OnCheckpointTriggered(this);
    }

    private void Awake()
    {
        triggerIsActive = false;
        playerInTrigger = false;
    }

    private void FixedUpdate()
    {
        if ((!CanTrigger) || needInteractWith)
        {
            return;
        }

        OnCheckpointTriggered();
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
            playerController.OnPlayerInteract.AddListener(OnCheckpointTriggered);
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
            playerController.OnPlayerInteract.RemoveListener(OnCheckpointTriggered);
        }
    }

}

[System.Serializable]
public class CheckpointStage
{
    public CheckpointTrigger[] stageCheckpoints;
}
