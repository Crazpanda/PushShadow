using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact2Disable : InteractableBase
{
    public GameObject[] objectsToDisable;

    public override void OnInteract()
    {
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}
