using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private MovementMotor motor;
    public float move_Magnitude = 0.05f;
    public float speed = 0.7f;
    public float turnSpeed = 10f;
    public float speed_Jump = 20f;
    private float speed_Move_Multiplier = 1f;
    private Vector3 direction;
    private Animator anim;
    private Camera mainCamera;
    private string PARAMETER_STATE = "Moving";
    public GameController GameController;

    void Awake () {
        motor = GetComponent<MovementMotor>();
        anim = GetComponent<Animator>();
	}
    void Start()
    {
        anim.applyRootMotion = false;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        MovementAndJumping();

    }

    private Vector3 MoveDirection
    {
        get { return direction; }
        set {
            direction = value * speed_Move_Multiplier;
            if(direction.magnitude >0.1f)
            {
                var newRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation,
                    Time.deltaTime * turnSpeed);
            }
            direction *= speed * (Vector3.Dot(transform.forward, direction) + 1f) * 5f;
            motor.Move(direction);

            AnimationMove(motor.charController.velocity.magnitude * 0.1f);
        }
    }

    void Moving(Vector3 dir, float mult)
    {
        speed_Move_Multiplier = 1 * mult;
        MoveDirection = dir;
    }

    [HideInInspector]
    public void Jump()
    {
        motor.Jump(speed_Jump);
    }

    void AnimationMove (float magnitude)
    {
        if(magnitude > move_Magnitude)
        {
            float speed_Animation = magnitude * 2f;

            if (speed_Animation < 1f)
                speed_Animation = 1f;

                anim.SetInteger(PARAMETER_STATE, 1);
                anim.speed = speed_Animation;
            if (GameController.gameOver == true)
            {
                anim.SetInteger(PARAMETER_STATE, 0);
            }
            } else
        {
                anim.SetInteger(PARAMETER_STATE, 0);
        }
    }

    void MovementAndJumping()
    {
        Vector3 moveInput = Vector3.zero;
        Vector3 forward = Quaternion.AngleAxis(-90, Vector3.up) * mainCamera.transform.right;
        moveInput += forward * Input.GetAxis("Vertical");
        moveInput += mainCamera.transform.right * Input.GetAxis("Horizontal");
        moveInput.Normalize();
        Moving(moveInput.normalized, 1f);

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
}
