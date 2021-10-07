using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActionTrigger : MonoBehaviour
{
    public uint StageId;
    public CameraActionManager1 Manager;
    public PlayerControllerCat PlayerCat;
    public PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.IsRunning() == false)
        {
            if(Player)
                Player.enabled = true;
            if (PlayerCat)
                PlayerCat.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player)
            Player.enabled = false;
        if (PlayerCat)
            PlayerCat.enabled = false;

        if (other.tag == "Player")
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
