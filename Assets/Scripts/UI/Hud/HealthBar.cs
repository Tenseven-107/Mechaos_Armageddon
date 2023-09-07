using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Entity player;
    public GameObject deathEffect;

    public Image heart, fill;
    public Slider slider;
    public Gradient gradient;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
        SetMaxHealth();
    }

    private void SetMaxHealth()
    {
        slider.maxValue = player.maxHP;
        slider.value = player.hp;

        fill.color = gradient.Evaluate(1f); // equals the colour that we get at the end of the gradient 
    }

    private void Update()
    {
        SetHealth();
    }

    private void SetHealth() 
    {
        slider.value = player.hp; //de slider staat gelijk aan de health

        fill.color = gradient.Evaluate(slider.normalizedValue); // makes it so the the gradient chooses between 1f and 3f
    
        if (slider.value <= 0) 
        {
            heart.enabled = false;
            // iets met emit doen en deathEffect
        }
    }
}
