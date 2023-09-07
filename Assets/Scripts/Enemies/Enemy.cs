using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 velocity = Vector2.zero;
    private bool moveToleft = true;
    public float speed = 1;

    Rigidbody2D rb;


    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveToleft) 
        {   // Speed
            velocity.x += 1 * speed;
        }else 
        {   // Speed
            velocity.x -= 1 * speed;
        }
        // zorgt ervoor dat de enemy niet sneller gaat dan de snelheid maar ook niet langzamer gaat dan de snelheid
        velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
        // je telt de values bij elkaar op en dat is de positie
        rb.MovePosition(rb.position + velocity * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // als de enemy tegen een muur aanloopt dan gaat het de andere kant op
        if (collision != null && collision.gameObject.tag == "Obstacle")
        {
            if (moveToleft)
            {
                moveToleft = false;
            }
            else  // als de enemy tegen een muur aanloopt dan gaat het de andere kant op
            {
                moveToleft = true;
            }
        }
    }
}



