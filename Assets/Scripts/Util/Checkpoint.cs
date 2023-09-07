using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    public bool activated = false;
    GameObject player;


    private void Start()
    {
        activated = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            activated = true;
        }
    }

    public void ResetCheckpoint()
    {
        activated = false;
    }
}
