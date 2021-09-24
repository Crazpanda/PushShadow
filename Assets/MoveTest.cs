using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float MoveSpeed = 100.0f;
    public float RotateSpeed = 100.0f;

    Vector3 RightDirect = new Vector3(1, 0, 0);
    Vector3 LeftDirect = new Vector3(-1, 0, 0);
    Vector3 WorldForward = new Vector3(0, 0, 1);
    Vector3 WorldBackward = new Vector3(0, 0, -1);

    Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Forward
        if(Input.GetKey(KeyCode.W))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), RightDirect);
            if (costhetaF >= 0.9 && costhetaF <= 1)
            {
                trans.forward = WorldForward;
                trans.position += trans.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                //rd : set rotate direct
                float rd = costhetaR > 0 ? -1 : 1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), RightDirect);
            if (costhetaR >= 0.9 && costhetaR <= 1)
            {
                trans.forward = RightDirect;
                trans.position += trans.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaF > 0 ? 1 : -1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            float costhetaF = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
            float costhetaL = Vector3.Dot(Vector3.Normalize(trans.forward), LeftDirect);
            if (costhetaL >= 0.9 && costhetaL <= 1)
            {
                trans.forward = LeftDirect;
                trans.position += trans.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaF > 0 ? -1 : 1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            float costhetaB = Vector3.Dot(Vector3.Normalize(trans.forward), WorldBackward);
            float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), RightDirect);
            if (costhetaB >= 0.9 && costhetaB <= 1)
            {
                trans.forward = WorldBackward;
                trans.position += trans.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                float rd = costhetaR > 0 ? 1 : -1;
                trans.Rotate(trans.up, rd * Time.deltaTime * RotateSpeed);
            }
        }
    }
}

