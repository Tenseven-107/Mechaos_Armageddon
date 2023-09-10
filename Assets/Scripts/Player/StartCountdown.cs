using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] int countdownTime = 3;

    Countdown gameCountdown;
    PlayerMovement player;
    TextMeshProUGUI text;


    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();
        player.locked = true;

        GameObject countObj = GameObject.FindGameObjectWithTag ("Countdown");
        gameCountdown = countObj.GetComponent<Countdown>();

        StartCoroutine(countdown());
    }

    IEnumerator countdown()
    {
        for (int i = countdownTime; i > 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        text.text = "GO!";
        player.locked = false;

        yield return new WaitForSeconds(0.5f);
        text.enabled = false;

        gameCountdown.StartCountdown();

        yield break;
    }
}
