using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage = 1; // Damage value
    public int team = 0; // This damage dealers team
    public bool physicsObject = false;


    // Deal damage when hitting target
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.GetComponent<Entity>();
        if (collider)
        {
            if (collider.team != team)
            {
                collider.HandleHit(damage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (physicsObject)
        {
            var collider = collision.gameObject.GetComponent<Entity>();
            if (collider && collider.team != team)
            {
                collider.HandleHit(damage);
            }
        }
        
    }
}
