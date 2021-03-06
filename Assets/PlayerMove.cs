using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;  
    public Transform PlayerModel;
    public Transform Camera;
    public Transform head;
    public Transform groundCheck;
    public float playerSpeed = 5f;
    public float sprint = 8f;
    public float crouch = 2.5f;
    public float jumpHeight = 1f;
    public float gravity = -19.62f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    // public gameObject PlayerModelObject;

    private Vector3 velocity;
    private bool isGrounded;

    public Animator animator;
    void Start()
    {
    //    scriptvobjectWithScript.GetComponent<ReferencedScript>();
        
    }

    void Update()
    {   
        Camera.transform.position = head.transform.position;
        float currentSpeed = playerSpeed;
        // float abc= test.isJumping;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // Checks if the player is on the ground
        bool isJumping = animator.GetCurrentAnimatorStateInfo(0).IsTag("jump2");
        
        if (isGrounded && velocity.y < 0) { // If the player is grounded and is not falling
            velocity.y = -2f; // then we set a constant gravity
        }

        float x = Input.GetAxis("Horizontal"); // Input for forwards and backwards (w and s)
        float z = Input.GetAxis("Vertical"); // Input for left and right (a and d)
        
        // Crouch
        if (Input.GetKey("left ctrl") || Input.GetKey("c") && isGrounded){ // press C or ctrl to crouch
            currentSpeed = crouch; // slow down when crouching
            controller.height = 1f; // Lower the height of the controller
            controller.center = new Vector3(0f, -0.35f, 0f); // Adjust the center of the controller to account for the reduced size 
        }
        else{
            controller.height = 1.7f; // Default height of controller
            controller.center = new Vector3(0f, 0f, 0f); // Default center of controller
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d")){
            currentSpeed = sprint;               
        }

        Vector3 moveDirection = PlayerModel.right * x + PlayerModel.forward * z; //Creates a vector with the direction of movement
    
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown("space") && isGrounded && !isJumping) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime; //Creates a vector with direction of gravity
        controller.Move(velocity * Time.deltaTime);

    }   
}
