using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotor : MonoBehaviour {

    public float gravityMultiplier = 1f;
    public float lerpTime = 10f;
    public Vector3 moveDirection = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;
    private float fallVelocity = 0f;
    public GameController GameController;
    //private Collision myCollider;
   [HideInInspector]
    public CharacterController charController;

    public float distanceToGround = 0.1f;

    [HideInInspector]
    public bool isGrounded;

    //Collision myCollider;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        //myCollider = GetComponent<Collision> ();
       

    }

    void Update()
    {
        if (GameController.gameOver == false)
        {
            isGrounded = OnGroundCheck();
            moveDirection = Vector3.Lerp(moveDirection, targetDirection, Time.deltaTime * lerpTime);
            moveDirection.y = fallVelocity;
            charController.Move(moveDirection * Time.deltaTime);
        }
        if(!isGrounded)
       {
            fallVelocity -= 90f * gravityMultiplier * Time.deltaTime;
       }

    }

    public bool OnGroundCheck()
    {

        if (charController.isGrounded)
        {
            return true;
        }
        /*
        if (myCollider.isCollided)
        {
            return true;
        }
        */
        
        
        return false;
    }

    public void Move(Vector3 dir)
    {
        targetDirection = dir;
    }
    public void Stop()
    {
        moveDirection = Vector3.zero;
        targetDirection = Vector3.zero;
    }
    Collision myCollider = GameObject.FindGameObjectWithTag("box").GetComponent<Collision>();
    public void Jump(float jumpSpeed)
    {
        if (isGrounded || myCollider.isCollided)
        {
            fallVelocity = jumpSpeed;
        }
    }

}
