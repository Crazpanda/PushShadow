using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraAction : MonoBehaviour
{
    public Camera TargetCamera;
    public Vector3[] PathSequence;

    bool isRunning = false;
    Vector2 beginPosition;
    Vector2 rectSize;
    uint currentFrame = 0;
    uint sequenceId = 0;
    float beginAspect;
    void Start()
    {
        beginPosition = TargetCamera.rect.position;
        rectSize = TargetCamera.rect.size;

        beginAspect = TargetCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            BeginAction();

        if (isRunning)
        {
            float t = (int)PathSequence[sequenceId].z <= 0 ? 1.01f : (float)(currentFrame) / PathSequence[sequenceId].z;
            if(t > 1)
            {
                t = 0;
                currentFrame = 0;
                sequenceId += 1;
                if (sequenceId >= PathSequence.Length)
                {
                    isRunning = false;
                    return;
                }
            }

            Action(t);

            currentFrame++;
            TargetCamera.aspect = beginAspect;
            TargetCamera.ResetAspect();

            Debug.Log(TargetCamera.aspect.ToString());
        }
    }

    void Action(float t)
    {
        Vector2 end = PathSequence[sequenceId];
        Vector2 begin = sequenceId==0?beginPosition: (Vector2)PathSequence[sequenceId - 1];

        Vector2 p = begin * (1 - t) + end * t;
        TargetCamera.rect = new Rect(p, rectSize);
    }

    public void BeginAction()
    {
        isRunning = true;
    }
}
