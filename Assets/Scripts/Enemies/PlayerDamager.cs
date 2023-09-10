using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    [SerializeField] int timeLoss = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag == "Player")
        {
            PlayerHitDetect playerHit = hitObject.GetComponent<PlayerHitDetect>();

            playerHit.HandleHit(timeLoss);
        }
    }
}
