using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioEvent : GameplayEvent
{
    public AudioSource audioSource;
    public override void OnEventTriggered()
    {
        audioSource.Play();
    }
}
