using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AIChase : MonoBehaviour
{
    public float speed;
    public float distanceBetween;
    public Area area; // Area of what the turret can see
    [Range(2, 20)] public float range = 6.5f; // Range of the turret
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (area != null && area.isColliding && area.getCollider() != null)
        {
            distance = Vector2.Distance(transform.position, area.getCollider().transform.position); // asgin a float and check the distance in short
            Vector2 direction = area.getCollider().transform.position - transform.position;
            direction.Normalize(); // give a direction/rotation to the enemy and conver a radian to degree
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, area.getCollider().transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); // rotates the enemy
        }

    }

    private void Update()
    {
        if (Application.isEditor && area != null) area.gameObject.transform.localScale = new Vector2(range, range);
    }
}
