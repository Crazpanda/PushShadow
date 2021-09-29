using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTest : MonoBehaviour
{
    public CameraAction action;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            action.BeginAction();
            action.SetFadeFactor(0.5f);
        }
    }

    private void OnMouseDown()
    {

    }
}
