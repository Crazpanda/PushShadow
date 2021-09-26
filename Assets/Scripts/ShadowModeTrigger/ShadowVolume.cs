using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShadowModeManager.Instance.OnPlayerEnterShadow(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShadowModeManager.Instance.OnPlayerExitShadow(this);
        }
    }
}
