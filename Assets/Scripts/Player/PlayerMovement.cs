using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float acceleration = 0.11f;
    [SerializeField] float decceleration = 0.08f;
    [SerializeField] float maxSpeed = 3.65f;
    float speed = 0f;

    [SerializeField] float turnAcceleration = 6.4f;
    [SerializeField] float maxTurnSpeed = 780.5f;
    float turnSpeed = 0f;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        PlayerRotation();
        PlayerMove();
    }


    void PlayerRotation()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal");
        float newRot = rb.rotation + (-rotationInput * turnSpeed) * Time.deltaTime;

        if (rotationInput != 0)
        {
            if (turnSpeed < maxTurnSpeed)
            {
                turnSpeed += turnAcceleration;
            }

            rb.MoveRotation(newRot);
        }
        else
        {
            turnSpeed = 0f;
        }
    }


    void PlayerMove()
    {
        float movementInput = Input.GetAxisRaw("Vertical");
        float moveForce = (movementInput * speed) * Time.deltaTime;

        if (movementInput != 0)
        {
            if (speed < maxSpeed)
            {
                speed += acceleration;
            }

            Vector2 velocity = transform.up * moveForce;
            rb.MovePosition(rb.position + velocity);
        }
        else
        {
            if (speed > 0)
            {
                speed -= decceleration;

                Vector2 decellVelocity = (transform.up * speed) * Time.deltaTime;
                rb.MovePosition(rb.position + decellVelocity);
            }
            if (speed < 0) speed = 0;
        }
    }
}
