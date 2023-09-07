using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    float finishTime = 0f;
    public float currentTime = 0f;
    public float bestTime = 0f;

    bool started = false;

    [SerializeField] int timeListSize = 3;

    public List<float> latestTimes = new List<float>();

    CheckpointManager checkpointManager;
    GameObject player;



    private void Start()
    {
        started = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            started = true;

            if (1 == 1)// Checkpointmanager.CheckClear()
            {
                finishTime = Time.time;
                ResetTimer();
            }
        }   
    }


    void ResetTimer()
    {
        if (currentTime < bestTime || bestTime == 0)
        {
            bestTime = currentTime;
        }

        latestTimes.Add(currentTime);
        if (latestTimes.Count > timeListSize)
        {
            latestTimes.RemoveAt(0);
        }

        currentTime = 0f;
    }

    private void Update()
    {
        if (started == true) currentTime = Time.time - finishTime;
    }
}
