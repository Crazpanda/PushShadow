using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActionTrigger : MonoBehaviour
{
    public uint StageId;
    public CameraActionManager1 Manager;
    public PlayerController PlayerCon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.IsRunning() == false)
            PlayerCon.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCon.enabled = false;

        if(other.tag == "Player")
        {
            switch(StageId)
            {
                case 0:
                    Manager.Stage0();
                    break;
                case 1:
                    Manager.Stage1();
                    break;
                case 2:
                    Manager.Stage2();
                    break;
                case 3:
                    Manager.Stage3();
                    break;
                default:
                    break;
            }
        }
    }
}
