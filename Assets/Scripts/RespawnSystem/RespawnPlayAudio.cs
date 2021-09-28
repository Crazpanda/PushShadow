using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayAudio : RespawnEventBase
{
    public AudioSource audioClip;
    public override void OnRespawnded(GameObject playerObject)
    {
        audioClip.Play();
    }
}
