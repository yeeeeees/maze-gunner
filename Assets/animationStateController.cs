using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Get current values of animation states
        bool isJogging = animator.GetBool("isJogging");
        bool isWalkingBack = animator.GetBool("isWalkingBack");
        bool isStrafeLeft = animator.GetBool("isStrafeLeft");
        bool isStrafeRight = animator.GetBool("isStrafeRight");
        bool isSprinting = animator.GetBool("isSprinting");
        
        // Check for input
        bool forwardPressed = Input.GetKey("w"); 
        bool backPressed = Input.GetKey("s"); 
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);


        // Forward Jogging
        if (!isJogging && forwardPressed) { // If player is not jogging and w is pressed  
            animator.SetBool("isJogging", true);  // then set isJogging to true
        }
        if (isJogging && !forwardPressed) { // If player is jogging and w is not pressed
            animator.SetBool("isJogging", false); // then set isJogging to false
        }

        // Backward Jogging
        if (!isWalkingBack && backPressed) {
            animator.SetBool("isWalkingBack", true);
        }
        if (isWalkingBack && !backPressed) {
            animator.SetBool("isWalkingBack", false);
        }

        // Strafe left
        if (!isStrafeLeft && leftPressed) {
            animator.SetBool("isStrafeLeft", true);
        }
        if (isStrafeLeft && !leftPressed) {
            animator.SetBool("isStrafeLeft", false);
        }

        // Strafe right
        if (!isStrafeRight && rightPressed) {
            animator.SetBool("isStrafeRight", true);
        }
        if (isStrafeRight && !rightPressed) {
            animator.SetBool("isStrafeRight", false);
        }

        // Sprinting
        if (!isSprinting && sprintPressed && forwardPressed) {
            animator.SetBool("isSprinting", true);
        }
        if (isSprinting && !sprintPressed || !forwardPressed) {
            animator.SetBool("isSprinting", false);
        }

    }
}
