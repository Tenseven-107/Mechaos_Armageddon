using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int hp = 3; // Entity hp
    public int maxHP = 3; // Entities max hp
    public int team = 0; // Entities team

    public bool godmode = false; // Godmode
    [HideInInspector] public bool invincible = false; // Invincible

    public float iFrameTime = 1; // I-frame time
    float last;

    public bool deactivate = true; // If entity should deactivate on death

    bool flash = true; // If enemy can flash
    WaitForSeconds flashTimer = new WaitForSeconds(0.05f);
    WaitForSeconds flashTimerShort = new WaitForSeconds(0.025f);
    SpriteRenderer sprite;
    public GameObject deathEffect;
    public Animator anims;

    public bool juice = false; // If enemy has screen fx
    [Range(0, 0.1f)] public float hitstopTime = 0;
    [Range(0, 1)] public float screenshakeTime = 0;
    [Range(0, 10)] public float screenshakeIntensity = 0;

    //public RandomAudio audio, healAudio; // Hit audio
    //public MechanicButton button; // If has an activatable


    // Set up
    private void Awake()
    {
        flash = true;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        flash = true;
        sprite.color = Color.white;

        last = Time.time;
        hp = maxHP;
    }


    // Handle damage
    public void HandleHit(int damage)
    {
        if (hp > 0 && !invincible)
        {
            if (Time.time - last < iFrameTime)
            {
                return;
            }
            last = Time.time;

            if (!godmode) hp -= damage;
            StartCoroutine(Flash());

            if (juice)
            {
                GameCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameCamera>();
                camera.hitstop(hitstopTime);
                camera.screenshake(screenshakeTime, screenshakeIntensity);
            }

            //if (audio != null) audio.PlaySound();

           // if (button != null) button.UpdateObjects();

            if (anims != null)
            {
                anims.ResetTrigger("Idle");
                anims.SetTrigger("Hit");
            }

            if (hp <= 0)
            {
                flash = false;
                Die();
            }
        }
    }


    // Handle heal
    public void HandleHeal(int addedHP)
    {
        if ((hp + addedHP > maxHP) == false)
        {
            hp += addedHP;

            if (juice)
            {
                GameCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameCamera>();
                camera.hitstop(hitstopTime);
                camera.screenshake(screenshakeTime, screenshakeIntensity);
            }

            //if (healAudio != null) healAudio.PlaySound();
        }
    }


    // Play hit flash animation
    IEnumerator Flash()
    {
        Color color = sprite.color;

        sprite.color = Color.red;
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


    // Die
    public void Die()
    {
        if (deathEffect != null)
        {
            Transform parent = transform.parent;
            Instantiate(deathEffect, transform.position, Quaternion.Euler(0, 0, 0), parent);
        }

        if (deactivate) gameObject.SetActive(false);
        else Destroy(gameObject);
    }
}
