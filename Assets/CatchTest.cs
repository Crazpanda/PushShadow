using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTest : MonoBehaviour
{
    public Camera camera;

    CameraAction[] actions;
    // Start is called before the first frame update
    void Start()
    {
        actions = camera.GetComponents<CameraAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (actions.Length > 0)
                actions[0].BeginAction();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (actions.Length > 1)
                actions[1].BeginAction();
        }
    }

    private void OnMouseDown()
    {

    }
}
