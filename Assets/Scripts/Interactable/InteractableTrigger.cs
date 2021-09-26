using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    public bool canInteractInShadowMode = true;
    public bool canInteractInNormalMode = true;

    public InteractableBase[] interactables;

    void OnInteract()
    {
        bool inShadowMode = ShadowModeManager.Instance.CurrentShadowMode == ShadowMode.Interactive;
        if ((inShadowMode && canInteractInShadowMode) || (!inShadowMode && canInteractInNormalMode))
        {
            foreach (var interactable in interactables)
            {
                interactable.OnInteract();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().OnPlayerInteract.AddListener(OnInteract);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().OnPlayerInteract.RemoveListener(OnInteract);
        }
    }
}