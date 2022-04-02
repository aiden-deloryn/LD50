using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public float maxVelocity;
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 inputForce = new Vector2(x, y);

        rb.AddForce(inputForce * Time.deltaTime * movementSpeed);
        Vector2 movement = rb.velocity;

        Vector2 velocity = rb.velocity;
        if (rb.velocity.y > maxVelocity)
        {
            movement.y = maxVelocity;
        }
        if (rb.velocity.x > maxVelocity)
        {
            movement.x = maxVelocity;
        }
        if (rb.velocity.y < -maxVelocity)
        {
            movement.y = -maxVelocity;
        }
        if (rb.velocity.x < -maxVelocity)
        {
            movement.x = -maxVelocity;
        }
        rb.velocity = movement;
    }
}
