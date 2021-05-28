using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // reference to the CharacterController
    private CharacterController m_CharacterController;
    // controls the speed of the character
    public float movementSpeed = 4f;
    // smoothing variable, controls the approximate the time it will take for
    // our character rotation angle to reach the target value
    public float turnSmoothTime = 0.2f;
    // The current velocity, this value is modified by the SmoothDampAngle
    // function every time you call it.
    float turnSmoothVelocity;
    // control the Leg Animation
    public WalkController[] walkControllers;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve reference to our CharacterController Component
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // retrieve the magnitude of movement on the "Horizontal" axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        // retrieve the magnitude of movement on the "Vertical" axis
        float vertical = Input.GetAxisRaw("Vertical");
        // using these magnitudes, determine the direction the character should
        // be heading towards
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // check if we are *significantly* moving in any direction
        if (direction.magnitude >= 0.1f)
            Move(direction);
        else
            Rest();
    }

    private void Rest()
    {
        for (int i = 0; i < walkControllers.Length; i++)
            walkControllers[i].ShouldStop();
    }

    private void Move(Vector3 direction)
    {
        // figure out the amount we need to rotate the character so it is "looking"
        // in the direction we are moving
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        // Gradually changes an angle towards a desired goal angle over time.
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
        ref turnSmoothVelocity, turnSmoothTime);
        // apply the smoothed angle
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        // move the character in the desired direction, multiplied by speed and
        // deltaTime
        m_CharacterController.Move(direction * movementSpeed * Time.deltaTime);

        for (int i = 0; i < walkControllers.Length; i++)
            walkControllers[i].ShouldMove();
    }
}
