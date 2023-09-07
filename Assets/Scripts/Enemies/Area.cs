using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public int targetTeam = 0; // The team of the target(s)
    [HideInInspector] public bool isColliding; // If is colliding with target
    public bool usesRaycast = true; // If object uses raycast
    bool rayColliding; // If raycast is colliding
    GameObject colliderObject;


    // Set Up
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }


    // Checking if colliding
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.GetComponent<Entity>() && collision.gameObject.GetComponent<Entity>().team == targetTeam)
        {
            colliderObject = collision.gameObject;
            Entity colliderEntity = colliderObject.GetComponent<Entity>();

            if (colliderEntity.team == targetTeam && ((rayColliding == true && usesRaycast == true) || usesRaycast == false))
            {
                isColliding = true;
            }
            else isColliding = false;
        }
    }

    private void FixedUpdate()
    {
        if (colliderObject != null && usesRaycast)
        {
            float distance = Vector2.Distance(transform.position, colliderObject.transform.position);
            Vector2 targetPos = colliderObject.transform.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, targetPos, distance);
            //Debug.DrawRay(transform.position, targetPos, Color.white); // Debugging

            if ( ray.collider != null && ray.collider.gameObject == colliderObject) rayColliding = true;
            else rayColliding = false;
        }
    }


    // When target exits view
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == colliderObject)
        {
            colliderObject = null;
            isColliding = false;
        }
    }


    // Get the collider
    public GameObject getCollider()
    {
        return colliderObject;
    }
}
