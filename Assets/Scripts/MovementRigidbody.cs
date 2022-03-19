using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;

    [Header("Player Basic Movement Components")]
    [SerializeField] private Vector3 movement;
    [Range(1,10)]
    public float moveXSpeed = 5;
    [Range(1,10)]
    public float moveZSpeed = 5;
    [Range(1,10)]
    public float jumpForce = 10f;
    
    public bool isRunning = false;
    [Range(1,10)]
    public float runningMultiplier = 2;
    public bool allowMove = true; //Added by John to stop movement when viewing objects or at the task desk

    void Update(){
        if (allowMove)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        }
        
    }

    void FixedUpdate(){

        if (allowMove)
        {
            ConfigureMovement(movement);
        }
       
    }

    void ConfigureMovement(Vector3 direction){
        Running();
        //Ensures movement is controlled by speed.
        direction.x *= moveXSpeed;
        direction.z *= moveZSpeed;

        if (isRunning == true){
            direction.z *= runningMultiplier;
        } 

        //Translates movement direction into global space.
        Vector3 MoveVector = transform.TransformDirection(direction);
        playerRB.velocity = new Vector3(MoveVector.x, playerRB.velocity.y, MoveVector.z);

        Jump();
    }

    void Jump(){
        //Jumping Movement
        if(Input.GetKeyDown(KeyCode.Space)){
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Running(){
        if(Input.GetKey(KeyCode.LeftShift)){
            isRunning = true;
        }else{
            isRunning = false;
        }
    }

    
}
