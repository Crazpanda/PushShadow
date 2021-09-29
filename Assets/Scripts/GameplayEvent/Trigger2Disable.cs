using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Disable : GameplayEvent
{
    public GameObject[] objectsToDisable;

    public override void OnEventTriggered()
    {
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}
