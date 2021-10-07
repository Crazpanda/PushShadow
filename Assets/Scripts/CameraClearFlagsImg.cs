using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraClearFlagsImg : MonoBehaviour
{
    public Texture imgBackground;
    public Canvas canvas;

    public Vector2 texScale = Vector2.one;
    public Vector2 texOffset = Vector2.zero;
    Camera cameraComp;
    void Start()
    {
        cameraComp = GetComponent<Camera>();
    }

    private void OnPreRender()
    {
        Texture2D overlay = new Texture2D((int)cameraComp.pixelRect.width, (int)cameraComp.pixelRect.height, TextureFormat.RGB24, true);
        //overlay.ReadPixels()
        Graphics.Blit(imgBackground, cameraComp.targetTexture, texScale, texOffset);
    }
}
