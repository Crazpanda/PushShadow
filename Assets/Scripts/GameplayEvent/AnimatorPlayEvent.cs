using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayEvent : GameplayEvent
{
    public Animation animationClip;
    public string clipToPlay;
    public override void OnEventTriggered()
    {
        animationClip[clipToPlay].wrapMode = WrapMode.Once;
        animationClip.Play(clipToPlay);
    }
}
