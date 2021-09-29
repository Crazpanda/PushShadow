using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraClearFlagsImg : MonoBehaviour
{
    public Texture imgBackground;
    public Vector2 texScale = Vector2.one;
    public Vector2 texOffset = Vector2.zero;
    Camera cameraComp;
    void Start()
    {
        cameraComp = GetComponent<Camera>();
    }

    private void OnPreRender()
    {
        Graphics.Blit(imgBackground, cameraComp.targetTexture, texScale, texOffset);
    }
}
