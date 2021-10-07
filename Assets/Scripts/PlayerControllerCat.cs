using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PlayerControllerCat : MonoBehaviour
{
    public float MaxMoveSpeed = 100.0f;
    public float RotateSpeed = 100.0f;

    public float gravityMultiplier = 0.5f;
    //public Transform CameraTrans;

    public MoveButton MobileMoveButton;
    public JumpButton MobileJumpButton;
    public SwitchButton MobileSwitchButton;

    public Animator CharacterAnimator;

    Vector3 playerVelocity;

    Transform trans;
    CharacterController controller;

    public UnityEvent OnPlayerInteract;

    void PlayerInteract()
    {
        OnPlayerInteract.Invoke();
    }

    public float JumpTime = 3;
    public float JumpSpeed = 0.0f;
    public float DropSpeed = 0.0f;
    float counter = 0;

    int animMoveStateHash;
    int animMoveSpeedHash;
    int animRotateSpeedHash;
    int animIsJumpHash;

    void PlayerMove2()
    {
        CharacterAnimator.SetFloat(animMoveSpeedHash, MaxMoveSpeed * 0.5f);
        CharacterAnimator.SetFloat(animRotateSpeedHash, RotateSpeed * 0.005f);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && vertical >= 0 && horizontal==0)
        {
            counter = JumpTime;

            CharacterAnimator.SetBool(animIsJumpHash,true);
        }
        else if(controller.isGrounded == true)
        {
            CharacterAnimator.SetBool(animIsJumpHash, false);
        }
        counter = Mathf.Max(counter - Time.deltaTime, 0);

        Vector3 gravity = Physics.gravity * gravityMultiplier;
        if (counter > 0)
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

        
        trans.Rotate(trans.up, Time.deltaTime * RotateSpeed * horizontal);

        //Move 
        Vector3 move = new Vector3(0.0f, 0.0f, vertical);
        if(vertical > 0)
        {
            CharacterAnimator.SetInteger(animMoveStateHash, 1);
        }
        else if (vertical < 0)
        {
            CharacterAnimator.SetInteger(animMoveStateHash, 2);
        }
        else
        {
            if (horizontal > 0)
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 4);
            }
            else if (horizontal < 0)
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 3);
            }
            else
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 0);
            }
        }

        controller.Move(trans.rotation * (move * Time.deltaTime * MaxMoveSpeed));

        playerVelocity += gravity * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);

        //Move

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }
    }

    void PlayerMove3()
    {

        CharacterAnimator.SetFloat(animMoveSpeedHash, MaxMoveSpeed * 0.5f);
        CharacterAnimator.SetFloat(animRotateSpeedHash, RotateSpeed * 0.005f);

        float horizontal = GetMobileHorizontal();
        float vertical = GetMobileVertical();

        if (MobileJumpButton.IsClick && controller.isGrounded && vertical >= 0 && horizontal == 0)
        {
            counter = JumpTime;

            CharacterAnimator.SetBool(animIsJumpHash, true);
        }
        else if (controller.isGrounded == true)
        {
            CharacterAnimator.SetBool(animIsJumpHash, false);
        }
        counter = Mathf.Max(counter - Time.deltaTime, 0);

        Vector3 gravity = Physics.gravity * gravityMultiplier;
        if (counter > 0)
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


        trans.Rotate(trans.up, Time.deltaTime * RotateSpeed * horizontal);

        //Move 
        Vector3 move = new Vector3(0.0f, 0.0f, vertical);
        if (vertical > 0)
        {
            CharacterAnimator.SetInteger(animMoveStateHash, 1);
        }
        else if (vertical < 0)
        {
            CharacterAnimator.SetInteger(animMoveStateHash, 2);
        }
        else
        {
            if (horizontal > 0)
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 4);
            }
            else if (horizontal < 0)
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 3);
            }
            else
            {
                CharacterAnimator.SetInteger(animMoveStateHash, 0);
            }
        }

        controller.Move(trans.rotation * (move * Time.deltaTime * MaxMoveSpeed));

        playerVelocity += gravity * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);

        //Move

        //if (MobileSwitchButton.IsClick)
        //{
        //    PlayerInteract();
        //}
    }

    void Start()
    {
        trans = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();

        playerVelocity = Vector3.zero;

        animMoveStateHash = Animator.StringToHash("MoveState");
        animMoveSpeedHash = Animator.StringToHash("AnimMoveSpeed");
        animRotateSpeedHash = Animator.StringToHash("AnimRotateSpeed");
        animIsJumpHash = Animator.StringToHash("IsJump");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove3();
    }

    float GetMobileVertical()
    {
        if (!MobileMoveButton) return 0.0f;

        float v = 0.0f;
        float theta = Vector2.Dot(new Vector2(0, 1), MobileMoveButton.HandleMovedDirection.normalized);
        if (Mathf.Abs(theta) > 0.8)
        {
            v = theta / Mathf.Abs(theta);
        }

        return v;
    }

    float GetMobileHorizontal()
    {
        if (!MobileMoveButton) return 0.0f;

        float v = 0.0f;
        float theta = Vector2.Dot(new Vector2(1, 0), MobileMoveButton.HandleMovedDirection.normalized);
        if (Mathf.Abs(theta) > 0.8)
        {
            v = theta / Mathf.Abs(theta);
        }

        return v;
    }
}
