using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    float finishTime = 0f;
    public float currentTime = 0f;
    public float bestTime = 0f;

    bool started = false;

    [SerializeField] public int timeListSize = 3;


    public List<float> latestTimes = new List<float>();

    [SerializeField] CheckpointManager checkpointManager;
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
            if (checkpointManager.CheckFinish())
            {
                started = true;

                finishTime = Time.time;
                ResetTimer();

                checkpointManager.ResetCourse();
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
