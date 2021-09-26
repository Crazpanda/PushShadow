using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float MaxMoveSpeed = 100.0f;
    public float RotateSpeed = 100.0f;

    public float gravityMultiplier = 0.5f;
    //public Transform CameraTrans;

    Vector3 playerVelocity;

    Vector3 WorldRightDirect = new Vector3(1, 0, 0);
    Vector3 WorldLeftDirect = new Vector3(-1, 0, 0);
    Vector3 WorldForwardDirect = new Vector3(0, 0, 1);
    Vector3 WorldBackwardDirect = new Vector3(0, 0, -1);

    Transform trans;
    CharacterController Controller;

    public UnityEvent OnPlayerInteract;

    void PlayerInteract()
    {
        OnPlayerInteract.Invoke();
    }

    void PlayerMove()
    {
        //Move 
        if (Input.GetKey(KeyCode.W))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForwardDirect);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), WorldRightDirect);
            if (costhetaF >= 0.9 && costhetaF <= 1)
            {
                trans.forward = WorldForwardDirect;
                trans.position += trans.forward * MaxMoveSpeed * Time.deltaTime;
            }
            else
            {
                //rd : set rotate direct
                float rd = costhetaR > 0 ? -1 : 1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForwardDirect);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), WorldRightDirect);
            if (costhetaR >= 0.9 && costhetaR <= 1)
            {
                trans.forward = WorldRightDirect;
                trans.position += trans.forward * MaxMoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaF > 0 ? 1 : -1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForwardDirect);
            float costhetaL = Vector3.Dot(Vector3.Normalize(trans.forward), WorldLeftDirect);
            if (costhetaL >= 0.9 && costhetaL <= 1)
            {
                trans.forward = WorldLeftDirect;
                trans.position += trans.forward * MaxMoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaF > 0 ? -1 : 1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float costhetaB = Vector3.Dot(Vector3.Normalize(trans.forward), WorldBackwardDirect);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), WorldRightDirect);
            if (costhetaB >= 0.9 && costhetaB <= 1)
            {
                trans.forward = WorldBackwardDirect;
                trans.position += trans.forward * MaxMoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaR > 0 ? 1 : -1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        //Move
    }

    void PlayerMove2()
    {
        Vector3 gravity = Physics.gravity * gravityMultiplier;

        bool groundedPlayer = Controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0.0f;
        }

        trans.Rotate(trans.up, Time.deltaTime * RotateSpeed * Input.GetAxis("Horizontal"));

        //Move 

        Vector3 move = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));

        Controller.Move(trans.rotation * (move * Time.deltaTime * MaxMoveSpeed));

        playerVelocity += gravity * Time.deltaTime;
        Controller.Move(gravity * Time.deltaTime);

        //Move
    }
    void Start()
    {
        trans = GetComponent<Transform>();
        Controller = GetComponent<CharacterController>();

        playerVelocity = Vector3.zero;

        //set WorldDirect
        //Vector3 projF = Vector3.Scale(CameraTrans.forward,new Vector3(1,0,1)).normalized;
        //Vector3 projR = Vector3.Scale(CameraTrans.right, new Vector3(1, 0, 1)).normalized;

        //WorldForwardDirect = projF;
        //WorldBackwardDirect = -projF;
        //WorldRightDirect = projR;
        //WorldLeftDirect = -projR;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove2();

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }

    }
}
