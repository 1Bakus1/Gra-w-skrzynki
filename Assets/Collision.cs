using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public GameObject Player;
    // public CharacterMovement Moving;
    //public MovementMotor Motor;
    public bool isCollided;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // Moving = GetComponent<CharacterMovement>();
        isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement Shot = other.GetComponent<CharacterMovement>();

        if (other.gameObject == Player)
        {
            isCollided = true;
            if (Shot != null)
            {
                Shot.Jump();
                
            }
            Destroy(this.gameObject);
           // Destroy(other.gameObject);
            CountingPoints.score++;
            isCollided = false;
        }
    }
}

