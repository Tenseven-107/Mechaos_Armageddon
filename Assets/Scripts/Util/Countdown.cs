using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI counter;

    [SerializeField] float countTime = 1.5f;
    [SerializeField] int startCount = 30;
    int currentCount = 0;

    PlayerMovement player;
    Finish finish;


    private void Start()
    {
        currentCount = startCount;
        counter.text = currentCount.ToString();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();

        GameObject finishObj = GameObject.FindGameObjectWithTag("Finish");
        finish = finishObj.GetComponent<Finish>();
    }


    IEnumerator CountdownLoop()
    {
        yield return new WaitForSeconds(countTime);
        currentCount--;

        counter.text = currentCount.ToString();

        if (currentCount <= 0)
        {
            GameOver();
            yield break;
        }
        else StartCoroutine(CountdownLoop());
    }


    void GameOver()
    {
        print("game over");
        player.locked = true;
        finish.StopTimer();
    }


    public void StartCountdown()
    {
        StartCoroutine(CountdownLoop());
    }


    public void RemoveCount(int count)
    {
        int removedCount = count;
        if (currentCount - count < 0)
        {
            removedCount = 1;
        }

        currentCount -= removedCount;
        counter.text = currentCount.ToString();

        if (currentCount <= 0)
        {
            GameOver();
        }
    }

    public void AddCount(int count)
    {
        currentCount += count;
        counter.text = currentCount.ToString();
    }
}
