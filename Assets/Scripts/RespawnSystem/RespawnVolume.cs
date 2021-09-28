using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnVolume : MonoBehaviour
{
    public Transform respawnPoint;
    public ShadowMode respawnedMode = ShadowMode.Normal;

    public RespawnEventBase[] respawnEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;
            characterController.enabled = true;
            ShadowModeManager.Instance.ChangeShadowMode(respawnedMode);

            if (respawnEvents.Length > 0)
            {
                GameObject playerObject = other.gameObject;
                foreach (var respawnEvent in respawnEvents)
                {
                    respawnEvent.OnRespawnded(playerObject);
                }
            }
        }
    }
}
