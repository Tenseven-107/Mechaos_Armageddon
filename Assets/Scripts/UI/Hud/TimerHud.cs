using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class TimerHud : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentTimer;
    [SerializeField] TextMeshProUGUI bestTimer;
    [SerializeField] List<TextMeshProUGUI> latestTimers = new List<TextMeshProUGUI>();

    Finish finish;


    private void Start()
    {
        GameObject finishObj = GameObject.FindGameObjectWithTag("Finish");
        finish = finishObj.GetComponent<Finish>();
    }


    private void Update()
    {
        FormatTimer(finish.currentTime, "Current: ", currentTimer);
        FormatTimer(finish.bestTime, "BEST: ", bestTimer);
        for (int i = 0; i < latestTimers.Count; i++) 
        {
            if (finish.latestTimes.Count == i + 1) FormatTimer(finish.latestTimes[i], "", latestTimers[i]);
        }
    }

    private void FormatTimer(float time, string timerName, TextMeshProUGUI timer)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = Mathf.FloorToInt((time - (int)time) * 1000);

        string timerTime = string.Format("{00:00}{1:00}{2:00}", minutes, seconds, milliseconds);
        timer.text = timerName + (timerTime[0].ToString() + timerTime[1].ToString() + ":" + timerTime[2].ToString() + timerTime[3].ToString() + "." + 
            timerTime[4].ToString() + timerTime[5].ToString());
    }
}
