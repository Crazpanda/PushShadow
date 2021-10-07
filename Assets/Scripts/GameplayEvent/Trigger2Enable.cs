using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Enable : GameplayEvent
{
    public GameObject[] objectsToEnable;

    public override void OnEventTriggered()
    {
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}