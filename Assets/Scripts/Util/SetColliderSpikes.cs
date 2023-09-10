using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetColliderSpikes : MonoBehaviour
{

    void Update()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();

        collider2D.size = new Vector2(sprite.size.x, collider2D.size.y);
    }
}
