using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraClearFlagsImg : MonoBehaviour
{
    public Texture imgBackground;
    public Canvas canvas;
    public Camera camera2D;

    public Vector2 texScale = Vector2.one;
    public Vector2 texOffset = Vector2.zero;
    void Start()
    {
        camera2D = GetComponent<Camera>();
    }

    private void OnPreRender()
    {        
        Graphics.Blit(imgBackground, camera2D.targetTexture, texScale, texOffset);
    }
}
