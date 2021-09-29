using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float MaxMoveSpeed = 100.0f;
    public float RotateSpeed = 100.0f;

    public float gravityMultiplier = 0.5f;
    //public Transform CameraTrans;

    public Button MobileMoveButton;
    public Button MobileRotateButton;
    
    Vector3 playerVelocity;

    Transform trans;
    CharacterController controller;

    MobileHandle moveHandle;
    MobileHandle rotateHandle;

    public UnityEvent OnPlayerInteract;

    void PlayerInteract()
    {
        OnPlayerInteract.Invoke();
    }

    public int JumpTime = 300;
    public float JumpSpeed = 0.0f;
    public float DropSpeed = 0.0f;
    int counter = 0;
    void PlayerMove2()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            counter = JumpTime;
        }
        counter = Mathf.Max(--counter, 0);

        Vector3 gravity = Physics.gravity * gravityMultiplier;
        if(counter > 0)
        {
            gravity = -gravity * JumpSpeed;
        }
        else
        {
            gravity = gravity * DropSpeed;
        }

        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0.0f;
        }

        trans.Rotate(trans.up, Time.deltaTime * RotateSpeed * Input.GetAxis("Horizontal"));
        
        //Move 

        Vector3 move = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));

        controller.Move(trans.rotation * (move * Time.deltaTime * MaxMoveSpeed));

        playerVelocity += gravity * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);

        //Move
    }

    void PlayerMove3()
    {
        //if (rotateHandle.IsClick)
        //{
        //    if (jumpHeight <= -JumpTime)
        //        jumpHeight = JumpTime;
        //}
        //jumpHeight = Mathf.Max(--jumpHeight, -10000);

        Vector3 gravity = Physics.gravity * gravityMultiplier;
        //if (jumpHeight > 0)
        //{
        //    gravity = -gravity * JumpSpeed;
        //}
        //else
        //{
        //    gravity = gravity * DropSpeed;
        //}

        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0.0f;
        }

        trans.Rotate(trans.up, Time.deltaTime * RotateSpeed * GetMobileHorizontal());

        //Move 
        Vector3 move = new Vector3(0.0f, 0.0f, GetMobileVertical());

        controller.Move(trans.rotation * (move * Time.deltaTime * MaxMoveSpeed));

        playerVelocity += gravity * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);

        //Move
    }

    void Start()
    {
        trans = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();

        playerVelocity = Vector3.zero;

        moveHandle = MobileMoveButton.GetComponent<MobileHandle>();
        rotateHandle = MobileRotateButton.GetComponent<MobileHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove2();

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }

    }

    //float GetMobileVertical()
    //{
    //    if (!moveHandle) return 0.0f;

    //    float v = moveHandle.HandleMovedDirection.y;
    //    v = v==0.0f?0.0f: v / Mathf.Abs(v);

    //    return v;
    //}

    //float GetMobileHorizontal()
    //{
    //    if (!rotateHandle) return 0.0f;

    //    float v = rotateHandle.HandleMovedDirection.x;
    //    v = v == 0.0f ? 0.0f : v / Mathf.Abs(v);

    //    return v;
    //}

    float GetMobileVertical()
    {
        if (!moveHandle) return 0.0f;

        float v = 0.0f;
        float theta = Vector2.Dot(new Vector2(0,1), moveHandle.HandleMovedDirection.normalized);
        if(Mathf.Abs(theta) > 0.8)
        {
            v = theta/ Mathf.Abs(theta);
        }
        
        return v;
    }

    float GetMobileHorizontal()
    {
        if (!rotateHandle) return 0.0f;

        float v = 0.0f;
        float theta = Vector2.Dot(new Vector2(1, 0), moveHandle.HandleMovedDirection.normalized);
        if (Mathf.Abs(theta) > 0.8)
        {
            v = theta / Mathf.Abs(theta);
        }

        return v;
    }
}
