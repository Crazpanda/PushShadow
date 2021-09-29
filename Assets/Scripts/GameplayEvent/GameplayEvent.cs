using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEvent : MonoBehaviour
{
    public virtual void OnEventTriggered()
    {
        Debug.LogWarning($"[GameplayEventBase] {gameObject.name} Interactable Behavior not implentmented.");
    }
}
