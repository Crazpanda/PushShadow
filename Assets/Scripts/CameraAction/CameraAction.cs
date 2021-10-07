using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraAction : MonoBehaviour
{
    
    public Vector3[] PathSequence;

    private Camera TargetCamera;

    bool isRunning = false;
    public bool IsRunning
    {
        get { return isRunning; }
    }

    Vector2 beginPosition;
    Vector2 rectSize;
    uint currentFrame = 0;
    uint sequenceId = 0;

    void Start()
    {
        TargetCamera = GetComponent<Camera>();

        beginPosition = TargetCamera.rect.position;
        rectSize = TargetCamera.rect.size;

    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    void Action(float t)
    {
        Vector2 end = PathSequence[sequenceId];
        Vector2 begin = sequenceId==0?beginPosition: (Vector2)PathSequence[sequenceId - 1];

        Vector2 p = begin * (1 - t) + end * t;
        TargetCamera.rect = new Rect(p, rectSize);
    }

    public Material PostProcessMat;
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (!PostProcessMat) return;

        PostProcessMat.SetFloat("_FadeFactor", fade);
        Graphics.Blit(src, dst, PostProcessMat);
    }

    //设置画面亮度
    float fade = 1.0f;
    public void SetFadeFactor(float f)
    {
        fade = f;
    }

    //启动摄像机运动
    public void BeginAction()
    {
        if (isRunning) return;

        beginPosition = TargetCamera.rect.position;
        currentFrame = 0;
        sequenceId = 0;

        isRunning = true;
    }
}
