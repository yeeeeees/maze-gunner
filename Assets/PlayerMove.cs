using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;  
    public Transform Camera;
    public float playerSpeed = 5f;
    public float sprint = 8f;
    public float jumpHeight = 300f;
    public float gravity = -19.62f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = playerSpeed;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // Checks if the player is on the ground

        if (isGrounded && velocity.y < 0) { // If the player is grounded and is not falling
            velocity.y = -2f; // then we set a constant gravity
        }

        float x = Input.GetAxis("Horizontal"); //Input for forwards and backwards (w and s)
        float z = Input.GetAxis("Vertical"); //Input for left and right (a and d)
        
        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d")){
            currentSpeed = sprint;               
        }

        Vector3 moveDirection = Camera.right * x + Camera.forward * z; //Creates a vector with the direction of movement
    
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown("space") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime; //Creates a vector with direction of gravity
        controller.Move(velocity * Time.deltaTime);
        print(currentSpeed);
    }   
}
