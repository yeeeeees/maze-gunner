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
    public Transform roofCheck;
    public float playerSpeed = 5f;
    public float sprint = 8f;
    public float crouch = 2.5f;
    public float slide = 10f;
    public float jumpHeight = 1f;
    public float gravity = -19.62f;
    public float groundDistance = 0.4f;
    public float roofDistance = 0.2f;
    public LayerMask groundMask;
    public LayerMask mazeMask;
    // public gameObject PlayerModelObject;

    private Vector3 velocity;
    private Vector3 slideForward;
    private Vector3 cameraOffSetZ = new Vector3(0f, 0f, -0.2f);
    private bool isGrounded;
    private bool isRoof;
    private bool isSliding;
    private float slideTimer;
    private float heightTimer;

    public Animator animator;
    void Start()
    {
    //    scriptvobjectWithScript.GetComponent<ReferencedScript>();
        
    }

    void Update()
    {   
        Camera.transform.position = head.transform.position;
        float currentSpeed = playerSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // Checks if the player is on the ground
        isRoof = Physics.CheckSphere(roofCheck.position, roofDistance, mazeMask); // Checks if there is anything above the player
        bool isJumping = animator.GetCurrentAnimatorStateInfo(0).IsTag("jump2");
        
        if (isGrounded && velocity.y < 0) { // If the player is grounded and is not falling
            velocity.y = -2f; // then we set a constant gravity
        }

        float x = Input.GetAxis("Horizontal"); // Input for forwards and backwards (w and s)
        float z = Input.GetAxis("Vertical"); // Input for left and right (a and d)
        
        // Crouch
        if (Input.GetKey("left ctrl") || Input.GetKey("c") && isGrounded && !isSliding){ // press C or ctrl to crouch
            currentSpeed = crouch; // slow down when crouching

            heightTimer += Time.deltaTime;
            if (heightTimer >= 0.3f){
                controller.height = 1f; // Lower the height of the controller
                controller.center = new Vector3(0f, -0.35f, 0f); // Adjust the center of the controller to account for the reduced size 
            }
        }
        else if (isRoof == false && !isSliding){
            controller.height = 1.7f; // Default height of controller
            controller.center = new Vector3(0f, 0f, 0f); // Default center of controller
        }

        if (isRoof == true && !isSliding){
            animator.SetBool("isCrouching", true);
            currentSpeed = crouch;
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d") && !isSliding){
            currentSpeed = sprint;               
        }

        // Sliding
        if (Input.GetKeyDown("left ctrl") && currentSpeed == sprint){
            slideTimer = 0f; // start timer
            isSliding = true;
            slideForward = transform.forward;    
        }

        if (isSliding){
            currentSpeed = slide - (slide * slideTimer)/2;

            slideTimer += Time.deltaTime;
            if (slideTimer >= 2f){
                isSliding = false;
                slideTimer = 0f;
                controller.height = 1f;
                controller.center = new Vector3(0f, -0.35f, 0f);
                // slideDrag = 1f - slideDrag;
            }
        }

        if (Input.GetKeyUp("left ctrl")){
            isSliding = false;  
            heightTimer = 0;
        }

        Vector3 moveDirection = PlayerModel.right * x + PlayerModel.forward * z; //Creates a vector with the direction of movement
    
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown("space") && isGrounded && !isJumping && currentSpeed != crouch) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime; //Creates a vector with direction of gravity
        controller.Move(velocity * Time.deltaTime);
        print(moveDirection);

    }   
}
