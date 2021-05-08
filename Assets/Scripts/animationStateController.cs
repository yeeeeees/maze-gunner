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
        bool isDiagonalRight = animator.GetBool("isDiagonalRight");
        bool isDiagonalLeft = animator.GetBool("isDiagonalLeft");
        bool isBackRight = animator.GetBool("isBackRight");
        bool isBackLeft = animator.GetBool("isBackLeft");
        bool isJumping = animator.GetBool("isJumping");
        bool isCrouching = animator.GetBool("isCrouching");
        bool isCrouchForward = animator.GetBool("isCrouchForward");
        bool isCrouchBackwards = animator.GetBool("isCrouchBackwards");
        bool isCrouchLeft = animator.GetBool("isCrouchLeft");
        bool isCrouchRight = animator.GetBool("isCrouchRight");
        bool isSlide = animator.GetBool("isSlide");
        
        // Check for input
        bool forwardPressed = Input.GetKey("w"); 
        bool backPressed = Input.GetKey("s"); 
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);
        bool spacePressed = Input.GetKeyDown("space");
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl);


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

        // Strafe Left
        if (!isStrafeLeft && leftPressed) {
            animator.SetBool("isStrafeLeft", true);
        }
        if (isStrafeLeft && !leftPressed) {
            animator.SetBool("isStrafeLeft", false);
        }

        // Strafe Right
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

        // Diagonal Forward Right
        if (!isDiagonalRight && rightPressed && forwardPressed) {
            animator.SetBool("isDiagonalRight", true);
        }
        if (isDiagonalRight && !rightPressed || !forwardPressed) {
            animator.SetBool("isDiagonalRight", false);
        }

        // Diagonal Forward Left
        if (!isDiagonalLeft && leftPressed && forwardPressed) {
            animator.SetBool("isDiagonalLeft", true);
        }
        if (isDiagonalLeft && !leftPressed || !forwardPressed) {
            animator.SetBool("isDiagonalLeft", false);
        }

        // Diagonal Backwards Right
        if (!isBackRight && rightPressed && backPressed) {
            animator.SetBool("isBackRight", true);
        }
        if (isBackRight && !rightPressed || !backPressed) {
            animator.SetBool("isBackRight", false);
        }

        // Diagonal Backwards Left
        if (!isBackLeft && leftPressed && backPressed) {
            animator.SetBool("isBackLeft", true);
        }
        if (isBackLeft && !leftPressed || !backPressed) {
            animator.SetBool("isBackLeft", false);
        }

        // Jumping
        if (!isJumping && spacePressed) {
            animator.SetBool("isJumping", true);
        }
        if (isJumping && !spacePressed) {
            animator.SetBool("isJumping", false);
        }

        // Crouch
        if (!isCrouching && crouchPressed) {
            animator.SetBool("isCrouching", true);
        }
        if (isCrouching && !crouchPressed) {
            animator.SetBool("isCrouching", false);
        }

        // Crouch Walk Forward
        if (!isCrouchForward && isCrouching && forwardPressed) {
            animator.SetBool("isCrouchForward", true);
        }
        if (isCrouchForward && !isCrouching || !forwardPressed) {
            animator.SetBool("isCrouchForward", false);
        }

        // Crouch Walk Backwards
        if (!isCrouchBackwards && isCrouching && backPressed) {
            animator.SetBool("isCrouchBackwards", true);
        }
        if (isCrouchBackwards && !isCrouching || !backPressed) {
            animator.SetBool("isCrouchBackwards", false);
        }

        // Crouch Walk Left
        if (!isCrouchLeft && isCrouching && leftPressed) {
            animator.SetBool("isCrouchLeft", true);
        }
        if (isCrouchLeft && !isCrouching || !leftPressed) {
            animator.SetBool("isCrouchLeft", false);
        }

        // Crouch Walk Right
        if (!isCrouchRight && isCrouching && rightPressed) {
            animator.SetBool("isCrouchRight", true);
        }
        if (isCrouchRight && !isCrouching || !rightPressed) {
            animator.SetBool("isCrouchRight", false);
        }

        // Slide
        if (!isSlide && crouchPressed && sprintPressed) {
            animator.SetBool("isSlide", true);
        }
        if (isSlide && !crouchPressed || !sprintPressed) {
            animator.SetBool("isSlide", false);
        }

    }
}
