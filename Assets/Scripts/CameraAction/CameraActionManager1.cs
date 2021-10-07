using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActionManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera CameraBig;
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;
    public Camera Camera4;

    CameraAction ActionBig;
    CameraAction Action1;
    CameraAction Action2;
    CameraAction Action3;
    CameraAction Action4;
    void Start()
    {
        CameraBig.rect = new Rect(new Vector2(0.2f, 0.51f), CameraBig.rect.size);
        Camera1.rect = new Rect(new Vector2(0.2f, 0.01f), Camera1.rect.size);
        Camera2.rect = new Rect(new Vector2(0.47f, 0.01f), Camera2.rect.size);
        Camera3.rect = new Rect(new Vector2(1.0f, 0.0f), Camera3.rect.size);
        Camera4.rect = new Rect(new Vector2(1.3f, 0.0f), Camera4.rect.size);

        ActionBig = CameraBig.GetComponent<CameraAction>();
        Action1 = Camera1.GetComponent<CameraAction>();
        Action2 = Camera2.GetComponent<CameraAction>();
        Action3 = Camera3.GetComponent<CameraAction>();
        Action4 = Camera4.GetComponent<CameraAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stage0()
    {
        Action1.BeginAction();
        Action2.BeginAction();
        Action3.BeginAction();
        Action4.BeginAction();

        ActionBig.BeginAction();
    }

    public void Stage1()
    {
        
    }

    public void Stage2()
    {

    }

    public void Stage3()
    {

    }

    public bool IsRunning()
    {
        if (ActionBig.IsRunning == false && Action1.IsRunning == false &&
            Action2.IsRunning == false && Action3.IsRunning == false &&
            Action4.IsRunning == false)
            return false;
        else
            return true;
    }
}
