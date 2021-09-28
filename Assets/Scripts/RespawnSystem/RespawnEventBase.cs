using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEventBase : MonoBehaviour
{
    public virtual void OnRespawnded(GameObject playerObject)
    {
        Debug.LogWarning($"[RespawnEvent] Not implentmented.");
    }
}
