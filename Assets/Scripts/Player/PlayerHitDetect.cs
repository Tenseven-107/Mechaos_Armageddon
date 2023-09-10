using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetect : MonoBehaviour
{
    public bool godmode = false; // Godmode

    public float iFrameTime = 1; // I-frame time
    float last;

    bool flash = true; // If enemy can flash
    WaitForSeconds flashTimer = new WaitForSeconds(0.05f);
    WaitForSeconds flashTimerShort = new WaitForSeconds(0.025f);
    public SpriteRenderer sprite;

    public bool juice = false; // If enemy has screen fx
    [Range(0, 0.1f)] public float hitstopTime = 0.07f;
    [Range(0, 1)] public float screenshakeTime = 0.2f;
    [Range(0, 10)] public float screenshakeIntensity = 0.5f;

    //public RandomAudio audio, healAudio; // Hit audio

    Countdown gameCountdown;


    // Set up
    private void Awake()
    {
        flash = true;
    }

    private void Start()
    {
        GameObject countObj = GameObject.FindGameObjectWithTag("Countdown");
        gameCountdown = countObj.GetComponent<Countdown>();
    }

    private void OnEnable()
    {
        flash = true;
        sprite.color = Color.white;

        last = Time.time;
    }


    // Handle damage
    public void HandleHit(int count)
    {
        if (godmode == false)
        {
            if (Time.time - last < iFrameTime)
            {
                return;
            }
            last = Time.time;

            gameCountdown.RemoveCount(count);

            StartCoroutine(Flash());
            if (juice)
            {
                GameCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameCamera>();
                camera.hitstop(hitstopTime);
                camera.screenshake(screenshakeTime, screenshakeIntensity);
            }

            //if (audio != null) audio.PlaySound();
        }
    }


    // Play hit flash animation
    IEnumerator Flash()
    {
        Color color = sprite.color;

        sprite.color = Color.cyan;
        yield return flashTimer;

        for (float n = 0; n < iFrameTime; n += 0.1f)
        {
            if (flash)
            {
                sprite.color = Color.clear;
                yield return flashTimerShort;
                sprite.color = color;
                yield return flashTimerShort;
            }
            else break;
        }
    }
}
