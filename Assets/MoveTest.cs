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
            trans.position += trans.forward * Time.deltaTime * MoveSpeed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            trans.position += -trans.right * Time.deltaTime * MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            trans.position += trans.right * Time.deltaTime * MoveSpeed;
        }
    }
}

/*
 else
        {
            //move right
            if(Input.GetKey(KeyCode.D))
            {
                float costhetaW = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
                float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), RightDirect);
                print($"Costheta {costhetaW} , {costhetaR}");
                if (costhetaW >= 0 && costhetaR >= 0)
                    trans.Rotate(trans.up, Time.deltaTime * RotateSpeed);
                else
                {
                    trans.forward = RightDirect;
                    trans.position += trans.forward * MoveSpeed * Time.deltaTime;
                }
            }
            //move left
            if(Input.GetKey(KeyCode.A))
            {
                float costhetaW = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
                float costhetaL = Vector3.Dot(Vector3.Normalize(trans.forward), LeftDirect);
                print($"Costheta {costhetaW} , {costhetaL}");
                if (costhetaW >= 0 && costhetaL >= 0)
                    trans.Rotate(trans.up, -Time.deltaTime * RotateSpeed);
                else
                {
                    trans.forward = LeftDirect;
                    trans.position += trans.forward * MoveSpeed * Time.deltaTime;
                }
            }
        }
 */

/*
 * //else
    //{
    //    //move right
    //    if(Input.GetKey(KeyCode.D))
    //    {
    //        float costhetaW = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
    //        float costhetaR = Vector3.Dot(Vector3.Normalize(trans.forward), RightDirect);
    //        if (costhetaW >= 0)
    //        {
    //            if(costhetaR)
    //        }
    //    }
    //    //move left
    //    if(Input.GetKey(KeyCode.A))
    //    {
    //        float costhetaW = Vector3.Dot(Vector3.Normalize(trans.forward), WorldForward);
    //        float costhetaL = Vector3.Dot(Vector3.Normalize(trans.forward), LeftDirect);
    //        if (costhetaW >= 0 && costhetaL >= 0)
    //            trans.Rotate(trans.up, -Time.deltaTime * RotateSpeed);
    //        else
    //        {
    //            trans.forward = LeftDirect;
    //            trans.position += trans.forward * MoveSpeed * Time.deltaTime;
    //        }
    //    }
    //}
 */
